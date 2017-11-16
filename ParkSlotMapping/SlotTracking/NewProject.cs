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

namespace ParkSlotMapping
{
    public partial class frmNewProject : Form
    {
        // passo al form principale il file del progetto (percorso)
        public string projectFile = "";
       
        private string projectFolder = "";
        private string sourceImage = "";    // used to store the source image path to file
        
        private smProject.FromFile newPrj_parameters;



        public frmNewProject()
        {
            DialogResult = DialogResult.Cancel;
            InitializeComponent();
            newPrj_parameters = new smProject.FromFile();
        }

        

        private void btBrowseFolder_Click(object sender, EventArgs e)
        {
            prjFolderBrowserDialog.ShowDialog();
            projectFolder = prjFolderBrowserDialog.SelectedPath;
            txtProjectFolder.Text = projectFolder;
            
        }

        private void btBrowseImage_Click(object sender, EventArgs e)
        {
            loadImage();
        }

        private void loadImage()
        {

            // open file dialog to choose an image as source for the project
            openImageDialog.ShowDialog();
            // when an image is choosen, save its path to the path variable
            sourceImage = openImageDialog.FileName;
            if (sourceImage != "")
            {
                try
                {
                    // load it into the preview box
                    Image prevImg = Image.FromFile(sourceImage);
                    picPreview.Image = prevImg;
                    // upgrade the txt with the path to the choosen image
                    txtImageFile.Text = sourceImage;
                }
                catch (System.SystemException) // if it goes wrong due to an invalid file, ask to choose a new one (erase content of variable, picbox and txtpath)
                {
                    MessageBox.Show("Please select a valid image file.", "Cannot open image", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    sourceImage = "";
                    txtImageFile.Text = "";
                    if(picPreview.Image!=null){picPreview.Image.Dispose();}
                    picPreview.Image = null;
                    loadImage();
                }
            }
            
        }

        private void openImageDialog_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        #region btMake
        //
        // btMake
        //
        private void btMake_Click(object sender, EventArgs e)
        {

            // check if project folder and name are selected (they're necessary)
            if (projectFolder == "")
            {
                MessageBox.Show("Select a folder path!", "No folder selected!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (newPrj_parameters.Name == "")
            {
                MessageBox.Show("Select name for your project!", "No project name!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (sourceImage == "")
            {
                MessageBox.Show("Select an image!", "No image file selected!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            // try to create dir, image(bmp) and prjFile
            try
            {
                createDir();
                createFiles();
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception exc)
            {
                if (exc.Message.Contains("image")) //detect any image error not specificatly handled
                {
                    MessageBox.Show("Image error, please select another one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    sourceImage = "";
                    txtImageFile.Text = "";
                    txtProjectFolder.Update(); // refresh the folder path
                    if (picPreview.Image!=null){picPreview.Image.Dispose();}
                    picPreview.Image = null;
                }
                return;
            }



        }

        private void createDir()
        {
            try
            {
                string folder2BeCreated = projectFolder + "\\" + newPrj_parameters.Name;  // path to the project directory to create

                if (Directory.Exists(folder2BeCreated)) // if the directory already exists, ask if it wants to replace it. If yes, delete all the project folder, else suggest to choose another name
                {
                    DialogResult result = MessageBox.Show(newPrj_parameters.Name + " folder already exist\nDo you want to replace it?", "Confirm create project", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        Directory.Delete(folder2BeCreated, true);
                    }
                    else
                    {
                        throw new ArgumentException("nwr"); // not rewrite
                    }
                }

                Directory.CreateDirectory(folder2BeCreated);
                projectFolder = folder2BeCreated;
            }
            
            catch (Exception exc)
            {
                if (exc.Message=="nwr")
                {
                    txtPrjName.Focus();
                    txtPrjName.Text = "";
                    throw;
                }
                MessageBox.Show(exc.Message, "Directory creation failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;
            }
        }

        private void createFiles()
        {
            IFormatter formatter = null;
            Stream stream = null;

            try
            {

                newPrj_parameters.imgReady = false;   // variables that indicates if a bmp image for tracking has been created
                createWorkImg(ref newPrj_parameters.imgReady);
                
                projectFile = (projectFolder + "\\" + newPrj_parameters.Name  + ".smprj");
                
                formatter = new BinaryFormatter();
                stream = new FileStream(projectFile, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, newPrj_parameters);
                stream.Close();
                
                
            }
            catch (Exception exc)
            {
                if (exc.Message != "load")
                { 
                    MessageBox.Show(exc.Message, "Files creation failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (stream != null)
                    {
                        stream.Close();  // if an exeption is thrown before the file was closed, close it
                    }
                }
                throw;
            }
        } 
      
        private void createWorkImg(ref bool _imgReady)
        {

            try
            {

                // if an image was selected, create the bitmap file that will be use to the tracking in the project directory 
                using (Image imgToSave = Image.FromFile(sourceImage))
                {
                    string path = projectFolder + "\\" + newPrj_parameters.Name + "_image.bmp";
                    
                    imgToSave.Save(path, System.Drawing.Imaging.ImageFormat.Bmp);
                    _imgReady = true;
                }
                   
            }
            catch (Exception exc)
            {
                sourceImage = "";
                txtImageFile.Text = "";
                if(picPreview.Image!=null){picPreview.Image.Dispose();}
                picPreview.Image = null;
                MessageBox.Show(exc.Message, "Bmp Image creation failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                throw;
            }
        }
           
        #endregion


        private void txtPrjName_TextChanged(object sender, EventArgs e)
        {
            // if the project name changes, I upgrade the public variable
            newPrj_parameters.Name = txtPrjName.Text;
            lblFolderName.Text = "\\" + newPrj_parameters.Name;
            // if a projectName and folder are selected, enable the make and image select buttons
            if (newPrj_parameters.Name != "" && projectFolder != "")
            {
                btMake.Enabled = true;
                btBrowseImage.Enabled = true;
            }
            else
            {
                btMake.Enabled = false;
                btBrowseImage.Enabled = false;
            }
        }

        private void txtProjectFolder_TextChanged(object sender, EventArgs e)
        {
            // if a projectName and folder are selected, enable the make and image select buttons
            if (projectFolder != "" && newPrj_parameters.Name != "")
            {
                btMake.Enabled = true;
                btBrowseImage.Enabled = true;
            }
            else
            {
                btMake.Enabled = false;
                btBrowseImage.Enabled = false;
            }
        }

        private void newProject_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (e.CloseReason == CloseReason.UserClosing)  
            {
                if (DialogResult!=DialogResult.OK) // if this method is not been called by the button Make -> set the projectFile null
                {
                    //if (Directory.Exists(projectFolder) && projectFile != "")  // se è stata creata la cartella del progetto e sto abortendo, la elimino
                    //{
                    //    Directory.Delete(projectFolder, true);
                    //}
                    projectFile = "";
                }
                
            }
                

            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                // Autosave and clear up ressources
                return;
            }
                
            
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
