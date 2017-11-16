using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkSlotMapping
{
    public partial class frmEditSlot : Form
    {

        parkingSlot newSlot;
        private bool is_new;

        // if I call this form passing an array enter "new slot mode"
        public frmEditSlot(Point[] _corners, slotsMap _targetmap, Bitmap img)
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;// set the default value of dialog result as cancel
            this.Text = "New Slot";  // change form name

            // be sure that the delete slot isn't visible 
            btDeleteSlot.Enabled = false;
            btDeleteSlot.Visible = false;


            // create new slot with corners array passed to the form  
            newSlot = new parkingSlot(_corners, _targetmap);

            cropImage(newSlot, img); // update the previwe image and write the corners coordinates

            // suggest a label
            txtLabel.Text = "SLOT" + newSlot.owner.get_nslot().ToString();

            is_new = true; // set flag to is_new -> new slot mode

        }

        public frmEditSlot(parkingSlot _slot, Bitmap img)
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel; // set the default value of dialog result as cancel

            // change form title
            this.Text = "Edit Slot";

            // be sure that the delete slot is enabled 
            btDeleteSlot.Enabled = true;
            btDeleteSlot.Visible = true;

            newSlot = _slot;
            
            // update image of the slot
            cropImage(_slot, img);

            // suggest a label
            txtLabel.Text = newSlot.label;

            // load the slot state
            radFull.Checked = newSlot.is_full;
            radEmpty.Checked = !(newSlot.is_full);

            is_new = false;  // set flag to is not new -> edit mode
        }

        private void frmNameSlot_Load(object sender, EventArgs e)
        {

        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                //set the new name
                if (txtLabel.Text == "")  // if the label is null -> exception
                {
                    throw new Exception("no_label");
                }
                
                if(newSlot.label != txtLabel.Text)  // if the name has chenged chech if is a valid name (univocal)
                {
                    if (newSlot.owner.slotlist.Exists(x => x.label == txtLabel.Text))  // if the destination map (owner) has already a slot with this label -> exception
                    {
                        throw new Exception("existing_label");
                    }
                    newSlot.label = txtLabel.Text;
                }
                
                // set the state (full-empty) according to the radio buttons 
                newSlot.is_full = radFull.Checked;

                if (is_new)  // if i'm creating a new slot, then
                {
                    // add the slot to the map
                    newSlot.owner.addSlot(newSlot);
                }
                
                
                //MessageBox.Show("The stlot " + newSlot.label + " has succesfully edited and saved", "Edit succesful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception exc)
            {
                string mex;
                switch (exc.Message)
                {
                    case "no_label":
                        mex = "Specify a label for the slot";
                        break;
                    case "existing_label":
                        mex = "A slot with label " + txtLabel.Text + " already exist.\nPlease choose a new one.";
                        txtLabel.Text = "";
                        txtLabel.Focus();
                        break;
                    default:
                        mex = exc.Message;
                        break;
                }

                MessageBox.Show(mex, "Slot editing error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }


    private void cropImage(parkingSlot _slot, Bitmap source) // update the previwe image and write the corners coordinates
        {

            parkingSlot.SlotRect r = _slot.s_rect();
            
            // create a blank image over whitch draw graphics
            picSlot.Image = new Bitmap(picSlot.Width, picSlot.Height);

            using (Graphics g = Graphics.FromImage(picSlot.Image))
            {
                Rectangle cropRect = new Rectangle();

                // sete the crop rectangel bounding the selected slot
                cropRect.Width = cropRect.Height = r.MaxSize + 20;

                cropRect.X = Math.Max(r.Xmin - (cropRect.Width - r.Width - 20) / 2 - 10, 0);
                cropRect.Y = Math.Max(r.Ymin - (cropRect.Height - r.Height - 20) / 2 - 10, 0);

                // crop the project image and load into picturebox of this form
                g.DrawImage(source, new Rectangle(0, 0, picSlot.Width, picSlot.Height), cropRect, GraphicsUnit.Pixel);
            } 
            

            txt0.Text = _slot.corners[0].ToString();
            txt1.Text = _slot.corners[1].ToString();
            txt2.Text = _slot.corners[2].ToString();
            txt3.Text = _slot.corners[3].ToString();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLabel_TextChanged(object sender, EventArgs e)
        {
            // if the text is not empty enable the confitm button
            btConfirm.Enabled = (txtLabel.Text != "");
        }

        private void btDeleteSlot_Click(object sender, EventArgs e)
        {
            if (!is_new)
            {
                newSlot.owner.deleteSlot(newSlot);
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void editSlot_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '\x1b':    // ESC -> CANCEL
                    btCancel_Click(null, null);
                    break;
                case '\x0d':  // ENTER -> CONFIRM BUTTON (IF ENABLED)
                    if (btConfirm.Enabled)
                    {
                        btConfirm_Click(null, null);
                    }
                    break;
                case '\x18':  // CANCEL -> IF IN EDIT SLOT MODE, DELETE SLOT
                    if (!is_new)
                    {
                        btDeleteSlot_Click(null, null);
                    }
                    break;
            }
        }

        /*
        private double quaddistance(Point p1, Point p2)
        {
            double d = Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2);  // calculate quadratic distance between two points
            return d;
        }
        */



    }

    

}
