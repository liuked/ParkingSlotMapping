using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Drawing.Imaging;

namespace ParkSlotMapping
{
    
    public partial class frmSlotMapping : Form
    {


        // control variables
        private smProject currentPrj;
        

        // features flags variables
        public bool mapping;  // mapping mode or not (enable commands and actions over the pictures)
        public bool drawing; // if i'm drawing a slot

        //zoom
        private int zoomFactor;  // between 2 and 8
        // image to crop the selection and zoom it into picZoom (2 is the factor of the zoom)
        private Bitmap imgZoom;
        private Rectangle cropRect;
        private Bitmap withGraphics;

        // drawing variables
        private bool is_firstpoint; // if the first point of a segment as been setted
        private Point[] cornersArray;  // I'm using an array instead of a complete slot variable becouse oi have the necessity to make changes in array dimensions and parkingSlot class, as i design it, doesn't allow that
        
        slotsMap.MouseOverClass mouse_over;

        // pan image variables (middle button or (Control+Left))
        private Point startingPoint;
        private Point movingPoint;
        private Point maxMove;
        private bool panning;

        private void thereIsAMap(bool presence)
        {

            btMapClear.Enabled = presence;
            mapToolStripMenuItem.Enabled = presence;
            btExportXML.Enabled = presence;
            exportXMLToolStripMenuItem.Enabled = presence;
            btExportBinary.Enabled = presence;
            exportBynaryToolStripMenuItem.Enabled = presence;
            numRotation.Enabled = presence;
            btRotation.Enabled = presence;
            btShift.Enabled = presence;


            //if (presence)
            //{
            //    numXshift.Maximum=picImage.With
            //    nu
            //}
        }

        private void prjEdited(bool _edited)
        {
            btSaveProject.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            currentPrj.edited = _edited;// mark the project as edited so i can ask for save data if the user try to close the application without saving

            if (_edited)
            {
                btSaveProject.ForeColor = Color.Red;  // HIGHLIGHT BUTTON SAVE
                btSaveProject.Font = new Font(btSaveProject.Font, FontStyle.Bold);
                this.Text = currentPrj.inFile.Name + "* - Park Slot Mapping";  // ADD ASTERIX TO FORM TEXT
                saveToolStripMenuItem.Font = new Font(saveToolStripMenuItem.Font, FontStyle.Bold);
            }
            else
            {

                this.Text = currentPrj.inFile.Name + " - Park Slot Mapping";
                btSaveProject.ForeColor = Color.Black;
                btSaveProject.Font = new Font(btSaveProject.Font, FontStyle.Regular);
                saveToolStripMenuItem.Font = new Font(saveToolStripMenuItem.Font, FontStyle.Regular);
            }

        }


        //
        // initializazion and features enabling functions
        //
        private void drawingEnable(bool enabled) // initialize or close drawing mode
        {
            picZoom.Image = null;
            drawing = enabled;
            pnlMapButtons.Enabled = !enabled;  // i can use the map actions (inport/export) only if i'm not in drawing mode
            btDraw.Enabled = !enabled;
            btCancelDrw.Enabled = enabled;
            
            // show/hide zoom elements
            lblZ.Visible = enabled;
            lblZoom.Visible = enabled;
            btZoomUp.Enabled = enabled;
            btZoomUp.Visible = enabled;
            btZoomDown.Enabled = enabled;
            btZoomDown.Visible = enabled;

            picZoom.Enabled = enabled;
            

            if (enabled)
            {
                picImage.Cursor = new Cursor(GetType(), "Marker.cur");
                this.Focus();

                // drawing variables
                is_firstpoint = true; // if the current point is the first of the slot
                cornersArray = null;
                
                zoomFactor = 2; // initialize zoom factor at 2
                lblZoom.Text = zoomFactor.ToString();


                if (currentPrj.inFile.Map == null)  // if there is no map create one where to save the slots (the map has to have the same size of the workingImage)
                {
                    currentPrj.inFile.Map = new slotsMap(currentPrj.workImg.Size);
                }
                
            }
            else
            {
                picImage.Cursor = Cursors.Arrow;
                

                btSaveImage.Enabled = true;  // i can save the image only if i'm not drawing
                saveImageToolStripMenuItem.Enabled = true;
            }

            picImage.Invalidate(); // initialize picture box

        }

        private void mappingEnable(bool enabled) // initialize or close mapping mode  (I call enabled true any time a valid image is loaded)
        {
            mapping = enabled;
            pnlMapping.Enabled = enabled;
            pnlMapButtons.Enabled = enabled;
            btSaveImage.Enabled = enabled;
            saveImageToolStripMenuItem.Enabled = enabled;
            //btToGrayscale.Enabled = enabled;
            barBrightness.Enabled = enabled;

            mapToolStripMenuItem.Enabled = true;

            // init panning variables
            startingPoint = Point.Empty;
            maxMove = Point.Empty;
            panning = false;
            movingPoint = Point.Empty;
            mouse_over = new slotsMap.MouseOverClass();

            if (enabled)
            {
                picImage.Enabled=true;
                //picImage.Focus();
                this.Focus();
                
                // set pen styles
                parkingSlot.slotPen = new Pen(Color.Fuchsia, 2);
                parkingSlot.markerPen = new Pen(Color.Lime, 1);
                parkingSlot.markerFont = new Font("Courier New", 10F, FontStyle.Bold, GraphicsUnit.Point);
                parkingSlot.slotFont = new Font("Courier New", 30F, FontStyle.Bold, GraphicsUnit.Point);
                parkingSlot.fillBrush = Brushes.Blue;


                // set the value of move coordinates (is negative becouse the picture is fixed at the upper left corner)
                if (currentPrj.workImg != null)
                {
                    withGraphics = new Bitmap(currentPrj.workImg);
                    currentPrj.AdjustedImage = new Bitmap(currentPrj.workImg);
                    maxMove = new Point(picImage.Size.Width - currentPrj.workImg.Size.Width, picImage.Size.Height - currentPrj.workImg.Size.Height);
                    lblMaxMove.Text = maxMove.ToString();
                }

                if (currentPrj.inFile.Map != null)
                {
                    thereIsAMap(true);
                }


                

            }
            else
            {
                if (currentPrj.workImg != null) { currentPrj.workImg.Dispose(); }
                picImage.Image = null;
                currentPrj.workImg = null;
                withGraphics = null;
                currentPrj.AdjustedImage = null;
                maxMove = Point.Empty;
                lblMaxMove.Text = maxMove.ToString();
                

                thereIsAMap(false);

            }
        }

        private void InitializeVariables()
        {

            // control variables
            currentPrj = new smProject();

            //currentPrj.Folder = ""; // stores the current project file path
            //currentPrj.WorkImg = null;
            //currentPrj.Name = "";
            //currentPrj.XMLFileName = "";
            //currentMap = null;
            //imgReady = false;
            //edited = false;

            mapping = false;
            drawing = false;

          
            // panning variabes + mapping controls
            mappingEnable(false); // disable all mapping features

            // drawings variables and controls
            drawingEnable(false);
            
            btSaveProject.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            picImage.Image = null;
            picImage.Enabled = false;
            btRevertImg.Enabled = true;

        }


        // 
        // SlotMapping
        // 
        public frmSlotMapping()
        {
            InitializeComponent();
            InitializeVariables();
        }


        
        private void slotMapping_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                closeProject();
            }
            catch (Exception exc)
            {
                switch (exc.Message)
                {
                    case "do_not_close":
                        break;
                    default:
                        MessageBox.Show(exc.Message, "Stop closing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                }
                e.Cancel = true;
            }
        }
        private void slotMap_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            switch (e.KeyChar) {

                case '\x8':  // BACKSPACE, REMOVE LAST POINT
                    if (drawing && cornersArray != null)
                    {
                        if (cornersArray.Length > 2)  // only if i have at least two fixed point and a float one (the one which moves with the mouse cursor) i can reduce the dimension
                        {
                            // remove the penultimate corner,
                            // ( copy the last corner in the penultimate one and remove last )
                            cornersArray[cornersArray.Length - 2] = cornersArray[cornersArray.Length - 1];
                            Array.Resize(ref cornersArray, cornersArray.Length - 1);
                        }
                        else  // otherwise it's time to reset drawing mode
                        {
                            drawingEnable(true); // reset drawing mode
                        }
                        picImage.Invalidate();
                    }
                    break;

                case '\x1b':  // ESC, EXIT DRAW MODE
                    if (drawing)
                    {
                        drawingEnable(false);
                        picImage.Invalidate(); 
                    }
                    break;

                case '\x2b':  // "+" INCREMENT ZOOM FACTOR (if drawing)
                    btZoomUp_Click(null, null);
                    break;

                case '\x2d':  // "-" DENCREMENT ZOOM FACTOR (if drawing)
                    if (drawing)
                    {
                        btZoomDown_Click(null, null); 
                    }
                    break;


                case '\x64':    // D
                case '\x44':    // d    -> toggle drawing IF MAPPING
                    if (mapping)
                    {
                        drawingEnable(!drawing); 
                    }
                    break;
            }
                
                

                

        }



        // 
        // btNewProject
        // 
        private void btNewProject_Click(object sender, EventArgs e)
        {

            if (currentPrj != null)  // if a project is already open, call the close function
            {
                try
                {
                    closeProject();
                }
                catch (Exception exc)
                {
                    return;
                }
            }

            var newProject = new frmNewProject();
            DialogResult result = newProject.ShowDialog();      // apro la finestra di caricamento immagine che mi rende disponibile il percorso del file progetto
            this.Show();
            if (result == DialogResult.OK)
            {
                try
                {
                    // function that read project file and load the needed files
                    openProject(newProject.projectFile);
                    btChangeImg.Enabled = true;
                    changeImageToolStripMenuItem.Enabled = true;
                }
                catch (Exception)
                {
                    return;
                }
            }
  
        }

        // 
        // btOpenProject
        //
        private void btOpenProject_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentPrj != null)
                {
                    closeProject();
                }

                string newPrjFile = "";
                openProjectDialog.FileName = ""; // reset file name
                openProjectDialog.ShowDialog();
                newPrjFile = openProjectDialog.FileName;
                if (newPrjFile != "")
                {
                    try
                    {
                        openProject(newPrjFile);
                        btChangeImg.Enabled = true;
                        changeImageToolStripMenuItem.Enabled = true;
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, "An error as occurred", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        //
        // project file routines
        //
        
        private void openProject(string fileName)
        {
            IFormatter formatter =null;
            Stream stream = null;
            try
            {
                // if exist open the file and read it (binary)
                if (!(File.Exists(fileName)))
                {
                    throw new Exception("File not found!");
                }

                formatter = new BinaryFormatter();
                stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                currentPrj.inFile = (smProject.FromFile)formatter.Deserialize(stream);
                stream.Close();

                currentPrj.folder = Path.GetDirectoryName(fileName);
                currentPrj.file = fileName;
                prjEdited(false);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "File reading failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (stream != null)
                {
                    stream.Close(); // if an exeption is thrown before the file was closed, close it
                }
                currentPrj = null;
                throw;
            }



            // Load the image

            try
            {
                if (!currentPrj.inFile.imgReady)
                {
                    DialogResult result = MessageBox.Show("Do you want to add one now?", "No Image Found", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        imgCreateBmp();
                    }
                }

                if (currentPrj.inFile.imgReady)
                {
                    imgLoad();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You may neet to load another image", "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }
        private void saveProject() // upgrade the projecr file with current info
        {
            IFormatter formatter =null;
            Stream stream = null;
            try
            {
                formatter = new BinaryFormatter();
                stream = new FileStream(currentPrj.file, FileMode.Open, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, currentPrj.inFile);
                stream.Close();

                MessageBox.Show("Project saved", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // now the project is marked as non edited -> button sabe disabled
                prjEdited(false);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString(), "Prj writing failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (stream != null)
                {
                    stream.Close(); // if an exeption is thrown before the file was closed, close it
                }
                return;
            }
        }  
        private void closeProject()
        {
            if (currentPrj!=null && currentPrj.edited)
            {
                DialogResult result = MessageBox.Show("Something in the project has changed.\nDo you want to close it without saving?", "Confirm close project", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                switch (result)
                {
                    case DialogResult.Yes:
                        break;
                    case DialogResult.No:
                        saveProject();
                        break;
                    case DialogResult.Cancel:
                        throw new Exception("do_not_close");
                        break;
                }

                this.Text = "Park Slot Mapping";
                btSaveProject.Enabled = false;
                saveToolStripMenuItem.Enabled = false;
            }

            // reinitialize workspace
            InitializeVariables();
        }

        // open (change) image button
        // 
        // btChangeImg
        //
        private void btChangeImg_Click(object sender, EventArgs e)
        {

            try
            {
                mappingEnable(false); // disable all mapping features
               
                imgCreateBmp(); // create bmp image and save it into prj folder
                if (currentPrj.inFile.imgReady)
                {
                    imgLoad();   // load the project image (.bmp in the prj folder) into the picturebox
                }

                prjEdited(true);  // mark the project as edited so i can ask for save data if the user try to close the application without saving
                                 // enable "save" button
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message+"\nYou may neet to load another image", "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        
        
        private void imgCreateBmp()  // create bmp image and save it into prj folder
        {
            currentPrj.inFile.imgReady = false;
            string selectedImage = ""; // init file variable
            openImageDialog.FileName = ""; // reset file name
            openImageDialog.ShowDialog();
            selectedImage = openImageDialog.FileName;
            if (selectedImage != "")
            {
                try
                {
                    using (Image Dummy = Image.FromFile(selectedImage))
                    {
                        string myPrjImage = currentPrj.folder + "\\" + currentPrj.inFile.Name + "_image.bmp";
                        if (selectedImage != myPrjImage) // only if i selected a different image than the current project image i can save it, otherwise i'll incurr in error
                        {
                            Dummy.Save(myPrjImage, System.Drawing.Imaging.ImageFormat.Bmp);
                        }

                    }

                    currentPrj.inFile.imgReady = true;
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Bmp Image creation failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    throw;
                }
                
                
            }
            
        }  // create a bmp image fron selectedImage and save it into the project folder

        
        private void imgLoad()
        {
            string path = currentPrj.folder + "\\" + currentPrj.inFile.Name + "_image.bmp";
            try
            {
                using (Image tempImg = new Bitmap(path)) 
                {
                    if (currentPrj.inFile.Map != null)
                    {
                        if (tempImg.Size != currentPrj.inFile.Map.mapsize) // if the new image size doesn't match the current map size i cannot load it. The user can clear the map before load a new image.
                        {
                            throw new Exception("The image is not compatible with the current map\n"
                                +"Project Image size = " + tempImg.Size.ToString()
                                + "\nMap size = " + currentPrj.inFile.Map.mapsize.ToString()
                                + "\nYou should load an image of the right size and then clear the map to add an image with different size");
                        }
                    }
                    currentPrj.workImg = new Bitmap(tempImg);
                    picImage.Image = currentPrj.workImg;
                }
                
                mappingEnable(true); // enable all mapping features
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message + "\nAdd a new image to continue", "Image loading failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mappingEnable(false); // disable all mapping features
                btChangeImg_Click(null, null);
            }
        } // load the project image (.bmp in the prj folder) into the picturebox


        // 
        // picSlotMap
        // 
       
        private void picSlotMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (mapping)
            {
                // Middle button or (Control+Left) - pan image
                if (e.Button == MouseButtons.Middle || (e.Button == MouseButtons.Left && Control.ModifierKeys == Keys.Control))
                {
                    panning = true;
                    startingPoint = new Point(e.Location.X - movingPoint.X, e.Location.Y - movingPoint.Y);

                }
                
            }



        }
        private void picSlotMap_MouseMove(object sender, MouseEventArgs e)
        {

            if (mapping)
            {
                lblCoord.Text = e.Location.ToString();
                
                // Middle button or (Control+Left) is down - pan image
                if (panning)
                {
                    movingPoint = new Point(e.Location.X - startingPoint.X, e.Location.Y - startingPoint.Y);
                    //picImage.Invalidate();
                }

                if (currentPrj.inFile.Map!= null)
                {
                    Point here = new Point(e.Location.X - movingPoint.X, e.Location.Y - movingPoint.Y);
                    if (currentPrj.inFile.Map.MouseOver(here) != null)  // if there is a ouseover situation, flag the selection so the paint envent can handle it
                    {
                        mouse_over.selected = true;
                        mouse_over.slot = currentPrj.inFile.Map.MouseOver(here);
                    }
                    else
                    {
                        mouse_over.selected = false;
                    }

                    //picImage.Invalidate();
                }

                picImage.Invalidate();

                // if I'm in drawing mode
                if (drawing)
                {
                    if (!is_firstpoint)   // if the first point of a segment was setted
                    {
                        cornersArray[cornersArray.Length - 1] = new Point(e.Location.X - movingPoint.X, e.Location.Y - movingPoint.Y);
                    }

                    picImage.Invalidate();
                    imgZoom = new Bitmap(picZoom.Width / zoomFactor, picZoom.Height / zoomFactor);  // set imgZoom as 1/zoomFactor of the dimensions of the picturebox thet display it -> zoom effect when it's loaded into the picturebox

                    using (Graphics g = Graphics.FromImage(imgZoom))
                    {
                        
                        // create a crop rectangle centered in mouse location and of the same size of imgZoom (hat has been perviously initialized with properly dimension accordinf to zoomFactor)
                        cropRect = new Rectangle(e.X-movingPoint.X - imgZoom.Width/2, e.Y - movingPoint.Y - imgZoom.Height/2, imgZoom.Width, imgZoom.Height);
                        // copy image cropped part (defined by cropRect) into imgZoom 
                        g.DrawImage(withGraphics, new Rectangle(0, 0, imgZoom.Width, imgZoom.Height), cropRect, GraphicsUnit.Pixel);
                        if (is_firstpoint)
                        {
                            parkingSlot.drawMarker(new Point(imgZoom.Width / 2, imgZoom.Height / 2), g); 
                        }
                    }
                    picZoom.Image = imgZoom;
                }


               
            }

        }
        private void picSlotMap_MouseUp(object sender, MouseEventArgs e)
        {
            // Middle button or (control+Left) - pan image
            if (e.Button == MouseButtons.Middle || (e.Button==MouseButtons.Left && Control.ModifierKeys==Keys.Control))
            {
                panning = false;
            }
            else if (e.Button == MouseButtons.Left)
            {
                // check if i'm in drwing mode and i'm not holding control(i'm panning with left button) 
                // and if the point is valid (is a point of the picture box)
                if (drawing) 
                {
                    if (validCorner(e.Location))
                    {

                        if (is_firstpoint)
                        {
                            cornersArray = new Point[1];
                            cornersArray[0] = new Point(e.Location.X - movingPoint.X, e.Location.Y - movingPoint.Y);
                            is_firstpoint = false;
                        }
                        if (cornersArray.Length == 4)
                        {
                            confirmSlot(cornersArray);
                        }
                        else {
                            Array.Resize(ref cornersArray, cornersArray.Length + 1);
                        } 
                    }
                    
                    
                }
                

            }

        }
        private void picSlotMap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (mouse_over.selected)
                {
                    editSlot(mouse_over.slot);
                }

            }
        }
        private void picSlotMap_Paint(object sender, PaintEventArgs e)
        {

            if (currentPrj != null)
            {
                if (currentPrj.AdjustedImage != null && withGraphics != null)
                {
                    NormalizeMovPoint();

                    using (Graphics g = Graphics.FromImage(withGraphics))
                    {
                        // redraw the base ("neat" original image) with atrributes (depends on which effect has been applied)
                        g.DrawImage(currentPrj.AdjustedImage, new Point(0, 0));

                        if (mouse_over.selected)
                        {
                            mouse_over.slot.Fill(g);
                        }

                        // redraw the map over the image
                        if (currentPrj.inFile.Map != null)
                        {
                            currentPrj.inFile.Map.Draw(g);
                        }

                        if (drawing)
                        {
                            parkingSlot.drawArray(cornersArray, g);
                        }
                    }
                    e.Graphics.DrawImage(withGraphics, movingPoint);

                }
            }


        }

        private void editSlot(parkingSlot _slot)
        {
            // open name slot form
            var nameSlot = new frmEditSlot(_slot, withGraphics);
            DialogResult result = nameSlot.ShowDialog();

            // if the slot has been edited,flag the edit
            if (result == DialogResult.OK)
            {
                prjEdited(true); // flag that the project has been edited (drawn someting or )
                  // save button enebled
            }
        }
        private void confirmSlot(Point[] corners)
        {
            // open name slot form
            var nameSlot = new frmEditSlot(corners, currentPrj.inFile.Map, withGraphics);
            DialogResult result = nameSlot.ShowDialog();

            // if the slot has been setted, so rest the drawing mode to draw a new one
            if (result == DialogResult.OK) {
                drawingEnable(true);

                // if i have added a slot i've edited the project
                prjEdited(true);  // flag that the project has been edited (drawn someting or )
                                  // save button enebled

                thereIsAMap(true);
            }
        }
        private void NormalizeMovPoint()
        {

            // no possibility to leave white space in the picturebox
            chkXover.Checked = false;
            chkYover.Checked = false;
            if (movingPoint.X < maxMove.X)
            {
                movingPoint.X = maxMove.X;
                chkXover.Checked = true;
            }
            if (movingPoint.X >0)
            {
                movingPoint.X = 0;
            }
            if (movingPoint.Y < maxMove.Y)
            {
                movingPoint.Y = maxMove.Y;
                chkYover.Checked = true;
            }
            
            if (movingPoint.Y > 0)
            {
                movingPoint.Y = 0;
            }
            lblMaxMove.Text = maxMove.ToString();
            lblMovPoint.Text = movingPoint.ToString();
        }
        private bool validCorner(Point p) // is the point inside the picturebox??
        {
            if (p.X > 0 && p.X < picImage.Width && p.Y > 0 && p.Y < picImage.Height)
            {
                return true;
            }
            else
            {
                return false; 
            }
                
        }

        private void updateZoom()
        {
            using (Bitmap temp = new Bitmap(picZoom.Width / zoomFactor, picZoom.Height / zoomFactor))
            {
                using (Graphics g = Graphics.FromImage(temp))
                {
                    // create a crop rectangle centered in mouse location and of the same size of imgZoom (hat has been perviously initialized with properly dimension accordinf to zoomFactor)
                    cropRect = new Rectangle(imgZoom.Width / 2 - temp.Width / 2, imgZoom.Height / 2 - temp.Height / 2, temp.Width, temp.Height);
                    // copy image cropped part (defined by cropRect) into imgZoom 
                    g.DrawImage(imgZoom, new Rectangle(0, 0, temp.Width, temp.Height), cropRect, GraphicsUnit.Pixel);

                }


                picZoom.Image = new Bitmap(temp);
            }
        }

        //
        // btDraw - button that enable the park slot drawing
        //
        private void btDraw_Click(object sender, EventArgs e)
        {
            drawingEnable(true);
        }
        
        private void btCancelDrw_Click(object sender, EventArgs e)
        {
            drawingEnable(false);
        }

        
        private void btSaveProject_Click(object sender, EventArgs e)
        {
            saveProject();
        }

        private void btExportXML_Click(object sender, EventArgs e)
        {
            string XMLFileName = "";
            saveMapDialog.Filter = "XML File(*.xml)|*.xml;";
            saveMapDialog.FileName = ""; // reset file name
            saveMapDialog.ShowDialog();
            XMLFileName = saveMapDialog.FileName;
            if (XMLFileName != "")
            {
                try
                {
                    currentPrj.ExportMapXML(XMLFileName, chkOCV.Checked); 
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Error while exporting XML file", "XML exporting error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
        }
        private void btExportBinary_Click(object sender, EventArgs e)
        {
            string mapSaveFile = "";
            saveMapDialog.Filter = "Map File(*.smmap)|*.smmap;";
            saveMapDialog.FileName = ""; // reset file name
            saveMapDialog.ShowDialog();
            mapSaveFile = saveMapDialog.FileName;
            if (mapSaveFile != "")
            {
                try
                {
                    currentPrj.ExportMapBinary(mapSaveFile);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error while saving the map", "Save file error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }          
            }
        }

        private void btSaveImage_Click(object sender, EventArgs e)
        {
            try
            {
                saveImg();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void saveImg()
        {
            string imageSaveFile = "";
            saveImageDialog.FileName = ""; // reset file name
            saveImageDialog.ShowDialog();
            imageSaveFile = saveImageDialog.FileName;

            // save the image only if i choose a valid name
            if (imageSaveFile != "")
            {
                try
                {
                    // (it can't be the image used for the project!)
                    if (imageSaveFile == currentPrj.folder + "\\" + currentPrj.inFile.Name + "_image.bmp")
                    {
                        throw new Exception("You cannot save over the image used for he project!");
                    }

                    System.Drawing.Imaging.ImageFormat format;
                    switch (Path.GetExtension(imageSaveFile).ToLower())
                    {
                        case ".bmp":
                            format = System.Drawing.Imaging.ImageFormat.Jpeg;
                            break;
                        case ".gif":
                            format = System.Drawing.Imaging.ImageFormat.Jpeg;
                            break;
                        case ".jpeg":
                            format = System.Drawing.Imaging.ImageFormat.Jpeg;
                            break;
                        case ".png":
                            format = System.Drawing.Imaging.ImageFormat.Jpeg;
                            break;
                        default:
                            format = null;
                            break;
                    }
                    if (format != null)
                    {
                        withGraphics.Save(imageSaveFile, format);
                    }
                    else
                    {
                        throw new Exception("Invalid file extension");
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error while saving the map: " + exc.Message, "Save file error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }

        
        private void btImportBinary_Click(object sender, EventArgs e)
        {
            
            try
            {
                mapClear();
                string mapFileToOpen = "";
                openMapDialog.Filter = "Map File(*.smmap)|*.smmap;";
                openMapDialog.FileName = ""; // reset file name
                openMapDialog.ShowDialog();
                mapFileToOpen = openMapDialog.FileName;
                if (mapFileToOpen != "")
                {
                    currentPrj.ImportFromBinary(mapFileToOpen);
                    MessageBox.Show("Map "+ mapFileToOpen+"  succesfully imported ", "Map importing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    prjEdited(true); // importerd a new map -> project edited
                    thereIsAMap(true);
                }
            }
            catch (Exception exc)
            {
                
            }
            
        }
        private void btImportXML_Click(object sender, EventArgs e)
        {
            try
            {
                mapClear();
                string XMLFileToOpen = "";
                openMapDialog.Filter = "XML File(*.xml)|*.xml;";
                openMapDialog.FileName = "";
                openMapDialog.ShowDialog();
                XMLFileToOpen = openMapDialog.FileName;
                if (XMLFileToOpen != "")
                {
                    currentPrj.ImportFromXML(XMLFileToOpen);
                    MessageBox.Show("XML " + XMLFileToOpen + "  succesfully imported ", "XML importing", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    prjEdited(true); // importerd a new map -> project edited
                    thereIsAMap(true);
                }
            }
            catch (Exception exc)
            {

            }
        }

        private void mapClear()
        {
            try
            {
                if (!(currentPrj.inFile.Map.saved))
                {
                    DialogResult result = MessageBox.Show("The current map has changed. Do you want to load a new one without saving it?", "Confirm import map", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            break;
                        case DialogResult.No:
                            throw new Exception("save_map_first");
                        case DialogResult.Cancel:
                            throw new Exception("cancel_import");
                    }
                }

                mouse_over = new slotsMap.MouseOverClass();
                currentPrj.inFile.Map = null;
                thereIsAMap(false);
                prjEdited(true); // canceled the map -> project modified
                picImage.Invalidate();
            }
            catch (Exception exc)
            {
                switch (exc.Message)
                {
                    case "cancel_import":
                        throw;
                    case "save_map_first":
                        btExportBinary_Click(null,null);
                        break;
                    default:
                        return;
                }
            }
        }

        private void btMapClear_Click(object sender, EventArgs e)
        {
            mapClear();
        }

        //private void btToGrayscale_Click(object sender, EventArgs e)
        //{
        //    btRevertImg.Enabled = true;
        //    float[][] colorMatrixElements = {
        //       new float[] {2,  0,  0,  0, 0},        // red 
        //       new float[] {0,  1,  0,  0, 0},        // green 
        //       new float[] {0,  0,  1,  0, 0},        // blue 
        //       new float[] {0,  0,  0,  1, 0},        // alpha 
        //       new float[] {.2f, .2f, .2f, 0, 1}};    // three translation

        //    ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

        //    currentPrj.attributes.SetColorMatrix(colorMatrix);
        //    picImage.Invalidate();

        //    progressBar.Visible = true;
        //    this.Enabled = false;

        //    if (currentPrj.workImg != null)
        //    {
        //        Bitmap d = currentPrj.workImg;

        //        progressBar.Value = 0;
        //        progressBar.Maximum = d.Width;
        //        progressBar.Step = 1;

        //        for (int i = 0; i < d.Width; i++)
        //        {

        //            for (int x = 0; x < d.Height; x++)
        //            {
        //                Color oc = d.GetPixel(i, x);
        //                int grayScale = (int)((oc.R * 0.3) + (oc.G * 0.59) + (oc.B * 0.11));
        //                Color nc = Color.FromArgb(oc.A, grayScale, grayScale, grayScale);
        //                d.SetPixel(i, x, nc);
        //            }

        //            progressBar.PerformStep();
        //        }
        //        picImage.Invalidate();
        //    }

        //    progressBar.Visible = false;
        //    this.Enabled = true;
        //}

        private void btRevertImg_Click(object sender, EventArgs e)
        {
            barBrightness.Value = 0;
            barContrast.Value = 5;
            createColorMatrix();
        }

        
        private void createColorMatrix()
        {
                        
            float contrast = (float)barContrast.Value / 5f;
            float brightness = (float)barBrightness.Value / 15f;

            lblBrightness.Text = brightness.ToString();
            lblContrast.Text = contrast.ToString();

            brightness -= (contrast-1)/3;

            float[][] floatColorMatrix = {
                new float[]{contrast, 0, 0, 0, 0},             // red 
                new float[]{0, contrast, 0, 0, 0},             // green
                new float[]{0, 0, contrast, 0, 0},             // blue
                new float[]{0, 0, 0, 1, 0},                     // alpha
                new float[]{ brightness, brightness, brightness, 1, 1}                      // translations
            };

            ColorMatrix newColorMat = new ColorMatrix(floatColorMatrix);
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(newColorMat);
            using (Graphics g = Graphics.FromImage(currentPrj.AdjustedImage))
            {
                // redraw the base ("neat" original image) with atrributes (depends on which effect has been applied)
                g.DrawImage(currentPrj.workImg, new Rectangle(0, 0, currentPrj.workImg.Width, currentPrj.workImg.Height), 0, 0, currentPrj.workImg.Width, currentPrj.workImg.Height, GraphicsUnit.Pixel, attributes);
            }
                
           
            picImage.Invalidate();

        }

        private void bar_Scroll(object sender, EventArgs e)
        {
            createColorMatrix();
            
        }
        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btZoomUp_Click(object sender, EventArgs e)
        {
            if (zoomFactor < 8)
            {
                ++zoomFactor;
                lblZoom.Text = zoomFactor.ToString();
                updateZoom();
            }
        }

        private void btZoomDown_Click(object sender, EventArgs e)
        {
            if (zoomFactor > 2)
            {
                --zoomFactor;
                lblZoom.Text = zoomFactor.ToString();
                updateZoom();
            }
        }

        private void btShift_Click(object sender, EventArgs e)
        {
            if (numXshift.Value != 0  || numYshift.Value != 0)
            {
                currentPrj.inFile.Map.shift((int)numXshift.Value, (int)numYshift.Value);
                prjEdited(true); // the map has been modified
                numXshift.Value = numYshift.Value = 0;
                picImage.Invalidate(); 
            }
        }

        private void btRotate_Click(object sender, EventArgs e)
        {
            if (numRotation.Value!=0)
            {
                currentPrj.inFile.Map.rotate((float)numRotation.Value / 10f);
                prjEdited(true); // the map has been modified
                numRotation.Value = 0;
                picImage.Invalidate(); 
            }
        }

        private void checkDebugOpt_CheckedChanged(object sender, EventArgs e)
        {
            pnlDebug.Enabled = checkDebugOpt.Checked;
            pnlDebug.Visible = checkDebugOpt.Checked;
        }

    }
}
