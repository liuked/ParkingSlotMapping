using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Imaging;
using System.Xml.Schema;
using System.Xml.Linq;

namespace ParkSlotMapping
{

    public class smProject
    {
        // control variables
        public string file;     // the current project FILE path
        public string folder;   // the folder path of the project
        public Bitmap workImg;  // current image on which we're working
        public Bitmap AdjustedImage;  // image with brightness and contrast modified
        private string xsdMarkup;       // XML schema

        public bool edited;       // if it's true some changes has been occurred in the project
        public FromFile inFile;

        public smProject()
        {
            file = "";
            folder = "";
            workImg = null;
            edited = false;
            inFile = new FromFile();
            loadXMLSchema();
        }

        private void loadXMLSchema()
        {
            xsdMarkup =
            @"<?xml version = '1.0'?>
              <xsd:schema xmlns:xsd = 'http://www.w3.org/2001/XMLSchema' attributeFormDefault = 'unqualified' elementFormDefault = 'qualified'>
                  <xsd:element name = 'slotsmap'>
                  <xsd:complexType>
                      <xsd:sequence>
                      <xsd:element name = 'parkingslot' maxOccurs = 'unbounded'>
                          <xsd:complexType>
                          <xsd:sequence>
                              <xsd:element name = 'corners'>
                              <xsd:complexType>
                                  <xsd:sequence>
                                  <xsd:element name = 'corner' minOccurs = '4' maxOccurs = '4'>
                                      <xsd:complexType>
                                      <xsd:sequence>
                                          <xsd:element name = 'X' type = 'xsd:int'/>
                                          <xsd:element name = 'Y' type = 'xsd:int'/>
                                      </xsd:sequence>
                                      <xsd:attribute name = 'number' type = 'xsd:int' use = 'required'/>
                                      </xsd:complexType>
                                  </xsd:element>
                                  </xsd:sequence>
                              </xsd:complexType>                                  
                              </xsd:element>                                   
                          </xsd:sequence>                                    
                          <xsd:attribute name = 'label' type = 'xsd:string' use = 'required'/>                                         
                          <xsd:attribute name = 'state' type = 'xsd:string' use = 'required'/>                                              
                          </xsd:complexType>                                               
                      </xsd:element>                                                
                      </xsd:sequence>                                                 
                      <xsd:attribute name = 'nslots' type = 'xsd:int' use = 'required'/>                                                      
                      <xsd:attribute name = 'width' type = 'xsd:int' use = 'required'/>                                                      
                      <xsd:attribute name = 'height' type = 'xsd:int' use = 'required'/>                                                      
                  </xsd:complexType>                                                       
                  </xsd:element>
              </xsd:schema>";

        }

        public void ExportMapXML(string path, bool opencv_storage)
        {
            try
            {
                if (inFile.Map == null)
                {
                    throw new Exception("Thete's no map to export, start draw a new one");
                }

                // Create the XmlDocument.
                XmlDocument doc = new XmlDocument();
                string doc_opening = "<?xml version=\"1.0\"?> \n";
                XmlAttribute attribute;
                if (opencv_storage)
                {
                    doc_opening += "<opencv_storage>\n" + "</opencv_storage>";
                    doc.LoadXml(doc_opening);
                    // Create a new slotMap element.
                    XmlElement nodes_number = doc.CreateElement("nodes_number");
                    nodes_number.InnerText = inFile.Map.get_nslot().ToString();
                    doc.DocumentElement.AppendChild(nodes_number);
                }
                else
                {
                    doc_opening += "<slotsmap>\n" + "</slotsmap>";
                    doc.LoadXml(doc_opening);

                    // nslot attribute
                    attribute = doc.CreateAttribute("nslots");
                    attribute.Value = inFile.Map.get_nslot().ToString();
                    doc.DocumentElement.Attributes.Append(attribute);

                    // size attributes
                    attribute = doc.CreateAttribute("width");
                    attribute.Value = inFile.Map.mapsize.Width.ToString();
                    doc.DocumentElement.Attributes.Append(attribute);
                    //
                    attribute = doc.CreateAttribute("height");
                    attribute.Value = inFile.Map.mapsize.Height.ToString();
                    doc.DocumentElement.Attributes.Append(attribute);
                }
               

                /*
                // nslot attribute
                XmlAttribute attribute = doc.CreateAttribute("nslots");
                attribute.Value = inFile.Map.get_nslot().ToString();
                doc.DocumentElement.Attributes.Append(attribute);

                // size attributes
                attribute = doc.CreateAttribute("width");
                attribute.Value = inFile.Map.mapsize.Width.ToString();
                doc.DocumentElement.Attributes.Append(attribute);
                //
                attribute = doc.CreateAttribute("height");
                attribute.Value = inFile.Map.mapsize.Height.ToString();
                doc.DocumentElement.Attributes.Append(attribute);
                */


                foreach (parkingSlot _slot in inFile.Map.slotlist)
                {
                    // Create a new slot element.
                    XmlElement slotElement = doc.CreateElement("parkingslot");

                    // Create attributes for lable and state and append them to the slot element.
                    attribute = doc.CreateAttribute("label");
                    attribute.Value = _slot.label;
                    slotElement.Attributes.Append(attribute);

                    attribute = doc.CreateAttribute("state");
                    if (_slot.is_full)
                        attribute.Value = "full";
                    else
                        attribute.Value = "empty";
                    slotElement.Attributes.Append(attribute);

                    doc.DocumentElement.AppendChild(slotElement);

                    // Create and append a child element for the corners  of the slot.
                    XmlElement cornersElement = doc.CreateElement("corners");

                    slotElement.AppendChild(cornersElement);

                    for (int i = 0; i < 4; ++i)
                    {
                        // Create and append a child element for the corner of the corners list.
                        XmlElement singleCornerElement = doc.CreateElement("corner");
                        attribute = doc.CreateAttribute("number");
                        attribute.Value = i.ToString();
                        singleCornerElement.Attributes.Append(attribute);

                        cornersElement.AppendChild(singleCornerElement);

                        // Create and append a child element for the X-coord of the corner.  
                        XmlElement xElement = doc.CreateElement("X");
                        xElement.InnerText = _slot.corners[i].X.ToString();
                        singleCornerElement.AppendChild(xElement);

                        // Introduce a newline character so that XML is nicely formatted.
                        singleCornerElement.InnerXml = singleCornerElement.InnerXml.Replace(xElement.OuterXml, "\n        " + xElement.OuterXml);

                        // Create and append a child element for the Y-coord of the corner.  
                        XmlElement yElement = doc.CreateElement("Y");
                        yElement.InnerText = _slot.corners[i].Y.ToString();
                        singleCornerElement.AppendChild(yElement);

                        // Introduce a newline character so that XML is nicely formatted.
                        singleCornerElement.InnerXml = singleCornerElement.InnerXml.Replace(yElement.OuterXml, "\n        " + yElement.OuterXml + "\n      ");


                        // Introduce a newline character so that XML is nicely formatted.
                        cornersElement.InnerXml = cornersElement.InnerXml.Replace(singleCornerElement.OuterXml, "\n      " + singleCornerElement.OuterXml);
                        if (i == 3) { cornersElement.InnerXml = cornersElement.InnerXml.Replace(singleCornerElement.OuterXml, singleCornerElement.OuterXml + "\n    "); }
                    }


                    // Introduce a newline character so that XML is nicely formatted.
                    slotElement.InnerXml = slotElement.InnerXml.Replace(cornersElement.OuterXml, "\n    " + cornersElement.OuterXml + "\n  ");

                }

                doc.Save(path);

            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message, "XML exporting failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                throw;
            }
        }

        public void ExportMapBinary(string path)
        {
            IFormatter formatter = null;
            Stream stream = null;
            try
            {

                if (inFile.Map == null)
                {
                    throw new Exception("Thete's no map to export, start draw a new one");
                }
                formatter = new BinaryFormatter();
                if (File.Exists(path))
                {
                    stream = new FileStream(path, FileMode.Open, FileAccess.Write, FileShare.None);
                }
                else
                {
                    stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                }
                formatter.Serialize(stream, inFile.Map);
                stream.Close();
                inFile.Map.saved = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString(), "Map exporting failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (stream != null)
                {
                    stream.Close(); // if an exeption is thrown before the file was closed, close it
                }
            }
        }

        public void ImportFromBinary(string path)
        {
            
            slotsMap temp;
            IFormatter formatter = null;
            Stream stream = null;
            try
            {
                // open the file and read it (binary)
                if (!(File.Exists(path)))
                {
                    throw new Exception("File not found!");
                }
                formatter = new BinaryFormatter();
                stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                temp = (slotsMap)formatter.Deserialize(stream);
                stream.Close();
                
                if (temp.mapsize != workImg.Size)
                {
                    throw new Exception("Map size is not compatible with this project!\n"
                        +"Project Image size = " + workImg.Size.ToString()
                        +"\nMap size = " + temp.mapsize.ToString());
                }
                
                inFile.Map = temp;
                
                inFile.Map.saved = true; // the new map has to be marked as "saved" becouse no editing has occours yet 
                
            }
            catch (Exception exc)
            {
                
                MessageBox.Show(exc.Message, "Map importing failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (stream != null)
                {
                    stream.Close(); // if an exeption is thrown before the file was closed, close it
                }
                throw;
                
            }
        }

        public bool XML_is_valid(string path)
        {
            XDocument doc = XDocument.Load(path);

            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", XmlReader.Create(new StringReader(xsdMarkup)));

            bool errors = false;
            doc.Validate(schemas, (o, e) =>
            {
                MessageBox.Show(e.Message, "Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errors = true;
            });
            return !errors;
        } // XML file validation Against XMLSchema

        public void ImportFromXML(string path)
        {
            try
            {
                // open the file and read it (binary)
                if (!(File.Exists(path)))
                {
                    throw new Exception("File not found!");
                }
                if (!XML_is_valid(path)) {
                    throw new Exception("File Not Valid");
                }
                
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(path);

                // firts of all read the size attributes and chack if the map is valid for the project
                Size readSize = new Size(
                    int.Parse(xDoc.DocumentElement.Attributes.GetNamedItem("width").Value),
                    int.Parse(xDoc.DocumentElement.Attributes.GetNamedItem("height").Value)
                    );


                if (readSize != workImg.Size)  // check if the size of the map is compatible with the image, else throw an exception
                {
                    throw new Exception("Map size is not compatible with this project!\n"
                        + "Project Image size = " + workImg.Size.ToString()
                        + "\nMap size = " + readSize);
                }


                slotsMap tempMap = new slotsMap(workImg.Size); // create a new temporary map with the same size of the current
                parkingSlot tempSlot;
                
                int readNSlots = int.Parse(xDoc.DocumentElement.Attributes.GetNamedItem("nslots").Value);

                // cycle through each child nones (parkinkslot) 
                foreach (XmlNode slotNode in xDoc.DocumentElement.ChildNodes)
                {
                    // theese are the parkinkslot nodes
                    //extract the label
                    string tempLabel = slotNode.Attributes.GetNamedItem("label").Value;
                    
                    // only if the read label is unique i can add the slot, although i can skip all the next passages
                    if (!(tempMap.slotlist.Exists(x => x.label == tempLabel)))
                    {
                        //extract the state
                        bool tempIsFull = false;
                        if (slotNode.Attributes.GetNamedItem("state").Value == "full")
                        {
                            tempIsFull = true;
                        }

                        Point[] tempCorners = new Point[4];
                    
                        // enter corners node
                        foreach (XmlNode cornersNode in slotNode.ChildNodes)
                        {
                        
                            // this is the corners node whish cointains the list of cotners
                            foreach (XmlNode singleCornerNode in cornersNode.ChildNodes)
                            {
                                int index = int.Parse(singleCornerNode.Attributes.GetNamedItem("number").Value);
                            
                                // extract X and Y coordinates of every corner
                                foreach (XmlNode element in singleCornerNode.ChildNodes) // parse all elements in single Corner Node
                                {
                                    switch(element.Name) // read the name element to estabilish if is x or Y and save the value to the relative corner
                                    {
                                        case "X":
                                            tempCorners[index].X = int.Parse(element.InnerText);
                                            break;
                                        case "Y":
                                            tempCorners[index].Y = int.Parse(element.InnerText);
                                            break;
                                    }

                                }
                            }
                        }

                        // now that i have enough informations i can build a new parkingSlot and add it to the map
                        tempSlot = new parkingSlot(tempCorners, tempMap);
                        tempSlot.label = tempLabel;
                        tempSlot.is_full = tempIsFull;
                        tempMap.addSlot(tempSlot);
                    }

                    // if the lable isn't unique do nothing ...
                    
                }

                if (tempMap.get_nslot() != readNSlots)  // if it results that the number of slots in tha map is different from the number of slots written in the file ->NOTIFY THAT
                {
                    MessageBox.Show("the number of slots imported is different from the number of slot written in the file:"
                        + "nSlots read = " + readNSlots.ToString()
                        + "\nnSlots imported = " + tempMap.get_nslot().ToString()
                        + "\n...probabily some slots were invalids",
                        "Warnimg! Something's gone wrong...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // load the readMap into the project
                inFile.Map = tempMap;
                inFile.Map.saved = true; // the new map has to be marked as "saved" becouse no editing has occours yet 

            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message, "XML importing failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;

            }
        }

        private void settings_ValidationEventHandler(object sender, System.Xml.Schema.ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
            {
                System.Windows.Forms.MessageBox.Show
                    ("The following validation warning occurred: " + e.Message);
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                System.Windows.Forms.MessageBox.Show
                    ("The following critical validation errors occurred: " + e.Message);
                Type objectType = sender.GetType();
            }

        }

        [Serializable]
        public class FromFile
        {
            public string Name;     // current project file NAME
            public bool imgReady;             // presence or not of the .bmp image in project folder
            public slotsMap Map;       // current unexported map 

            public FromFile()
            {
                Name = "";
                imgReady = false;
                Map = null;
            }

        }

    }

    [Serializable]
    public class parkingSlot
    {
        public string label;
        public Point[] corners;
        public bool is_full;
        private SlotRect sRect;
        private Bitmap slotArea; // contain the shape of the slot drawn in black over white used to detect a MouseOver situation (with color check)
        public slotsMap owner;

        public parkingSlot(Point[] _corners, slotsMap _owner)
        {
            try
            {
                corners = new Point[4];
                for (int i = 0; i < 4; ++i)
                {
                    corners[i] = _corners[i];
                }
                label = "";
                is_full = false;
                owner = _owner; // add reference to the map that own this slot
                
                slotArea = new Bitmap(1, 1);
                slotArea.SetPixel(0, 0, Color.White);
                slotArea = new Bitmap(slotArea, owner.mapsize.Width, owner.mapsize.Height);

                // draw the slot area into the image used to detect Mouseover situation and recalculate the outer rectangle
                updateSlot();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Slot creation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void updateSlot()// draw the slot area into the image used to detect Mouseover situation
        {
            using (Graphics g = Graphics.FromImage(slotArea))
            {
                g.Clear(Color.White);
                g.FillPolygon(Brushes.Black, corners, System.Drawing.Drawing2D.FillMode.Winding);
            }
            // extract the rectangle that contains the slot
            sRect = new SlotRect(this);
        }

        public bool MouseOver(Point _location)
        {
            //MessageBox.Show(slotArea.GetPixel(_location.X, _location.Y).ToString());
            return (slotArea.GetPixel(_location.X, _location.Y).ToArgb() == Color.Black.ToArgb());
        }

        public void Draw(Graphics _dest)
        {
            slotFont = parkingSlot.slotFont = new Font("Courier New", sRect.MaxSize/10, FontStyle.Bold, GraphicsUnit.Point);

            drawArray(corners, _dest);
            _dest.DrawString(label, slotFont, slotPen.Brush, new Point(sRect.Xmin + sRect.Width / 5, sRect.Ymin + sRect.Height / 3));

        }

        public void Fill(Graphics _dest)
        {
            _dest.FillPolygon(fillBrush, corners, System.Drawing.Drawing2D.FillMode.Winding);
        }

        // method to return sRect value (it makes this attribute an only read one)
        public SlotRect s_rect() { return sRect; }

        [Serializable]
        public class SlotRect  // class that provide calculation of maximum and minimum values of x and y coordinates for a slot (dimensions and corners of the rectangle that contain the slot)
        {
            public int Xmin;
            public int Xmax;
            public int Ymin;
            public int Ymax;
            public int Width;
            public int Height;
            public int MaxSize;  // maximum size of the rectangle that contain the slot

            public SlotRect(parkingSlot _slot) 
            {
                // initialize variables to find X-Y max-min
                Xmin = 65535;
                Xmax = 0;
                Ymin = 65535;
                Ymax = 0;
                                
                for (int i = 0; i < 4; ++i)
                {
                    if (_slot.corners[i].X > Xmax)
                    {
                        Xmax = _slot.corners[i].X;
                    }
                    if (_slot.corners[i].X < Xmin)
                    {
                        Xmin = _slot.corners[i].X;
                    }
                    if (_slot.corners[i].Y > Ymax)
                    {
                        Ymax = _slot.corners[i].Y;
                    }
                    if (_slot.corners[i].Y < Ymin)
                    {
                        Ymin = _slot.corners[i].Y;
                    }
                }

                Width = Xmax - Xmin;
                Height = Ymax - Ymin;
                MaxSize = Math.Max(Width, Height);
            }
        }

        /// <summary>
        /// STATIC ELEMENTS
        /// </summary>

        // drawing preferences
        public static Pen slotPen;
        public static Pen markerPen;
        public static Font slotFont;
        public static Font markerFont;
        public static Brush fillBrush;

        public static void drawMarker(Point _here, Graphics target)  // write a crossed circle on the point "_here"
        {
            //orizontal line
            Point p1 = new Point(_here.X + 10, _here.Y);
            Point p2 = new Point(_here.X - 10, _here.Y);
            target.DrawLine(markerPen, p1, p2);
            //vertical line
            p1 = new Point(_here.X, _here.Y + 10);
            p2 = new Point(_here.X, _here.Y - 10);
            target.DrawLine(markerPen, p1, p2);
            //circle
            target.DrawEllipse(markerPen, _here.X - 5, _here.Y - 5, 10, 10);
        }

        public static void drawArray(Point[] source, Graphics target)  // cancel grafics and redraw all
        {

            if (source != null)
            {
                target.DrawPolygon(slotPen, source);
                for (int j = 0; j < source.Length; ++j)
                {
                    drawMarker(source[j], target);
                    target.DrawString(j.ToString(), markerFont, markerPen.Brush, new Point(source[j].X + 2, source[j].Y + 2));
                }
            }

        }

        

    }

    [Serializable]
    public class slotsMap
    {

        public List<parkingSlot> slotlist;
        private int nSlots; 
        public Size mapsize;
        public bool saved;  // flags if the map has been exported in binary

        public slotsMap(Size _size)
        {
            slotlist = new List<parkingSlot>();
            nSlots = 0;
            mapsize = _size;
            saved = false;
        }

        public void addSlot(parkingSlot _new)
        {
            slotlist.Add(_new);
            ++nSlots;
            saved = false; // map edited -> no more up to date
        }
        public void deleteSlot(parkingSlot _todelete)
        {

            try
            {
                slotlist.Remove(slotlist.Find(x => x.label == _todelete.label));
                --nSlots;
                saved = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Slot delete failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }

        public parkingSlot MouseOver(Point _location)  // return null if there isn't any mouseover situation in the spacified location, or the specific slot if there is.
        {
            foreach(parkingSlot _slot in slotlist)
            {
                if (_slot.MouseOver(_location))
                {
                    return _slot;
                }
                
            }
            return null;
        }

        public void rotate(float angleInDegrees)
        {
            double angleInRadians = angleInDegrees * (Math.PI / 180);
            double cosTheta = Math.Cos(angleInRadians);
            double sinTheta = Math.Sin(angleInRadians);
            Point centerPoint = new Point(mapsize.Width / 2, mapsize.Height / 2);
            Point destinationPoint;
            foreach (parkingSlot _slot in slotlist)
            {
                for (int i = 0; i < 4; ++i)
                {
                    destinationPoint =  new Point
                    {
                        X =
                        (int)
                        (cosTheta * (_slot.corners[i].X - centerPoint.X) -
                         sinTheta * (_slot.corners[i].Y - centerPoint.Y) + centerPoint.X),
                        Y =
                        (int)
                        (sinTheta * (_slot.corners[i].X - centerPoint.X) +
                         cosTheta * (_slot.corners[i].Y - centerPoint.Y) + centerPoint.Y)
                    };
                    _slot.corners[i] = new Point(destinationPoint.X,destinationPoint.Y);
                }
                _slot.updateSlot();
            }
            MessageBox.Show("Rotation of " + angleInDegrees.ToString() + " degrees applied", "Map Rotation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            saved = false;  // map modified
        }

        public void shift(int xShift, int yShift)
        {
            foreach (parkingSlot _slot in slotlist)
            {
                for (int i = 0; i < 4; ++i)
                {
                    _slot.corners[i].X += xShift;
                    _slot.corners[i].Y += yShift;
                }
                _slot.updateSlot();
            }
            MessageBox.Show("Shift of X:" + xShift.ToString()+ ", Y:" +yShift.ToString()+" pixels applied", "Map Shift", MessageBoxButtons.OK, MessageBoxIcon.Information);
            saved = false; // map modified
        }

        public int get_nslot() { return nSlots; }

        public void Draw(Graphics dest)
        {
            foreach (parkingSlot _slot in slotlist)
            {
                _slot.Draw(dest);
            }
        }

        public class MouseOverClass // class to identify the selection of a slot (method MouseOver) and  providse information in order to draw the selection in picImage Paint event
        {
            public bool selected;  // if  I have a selection
            public parkingSlot slot;  // which slot is selected

            public MouseOverClass()
            {
                selected = false;
                slot = null;
            }
        }

    }
}
