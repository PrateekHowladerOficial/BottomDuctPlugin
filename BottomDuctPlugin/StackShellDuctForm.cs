using System;

namespace BottomDuctPlugin
{
    public partial class StackShellDuctForm : Tekla.Structures.Dialog.PluginFormBase
    {
        
        public StackShellDuctForm()
        {
            InitializeComponent();
        }

        private void OkApplyModifyGetOnOffCancel_OkClicked(object sender, EventArgs e)
        {
            this.Apply();
            this.Close();
        }

        private void OkApplyModifyGetOnOffCancel_ApplyClicked(object sender, EventArgs e)
        {
            this.Apply();
        }

        private void OkApplyModifyGetOnOffCancel_ModifyClicked(object sender, EventArgs e)
        {
            this.Modify();
            
        }

        private void OkApplyModifyGetOnOffCancel_GetClicked(object sender, EventArgs e)
        {
            this.Get();
        }

        private void OkApplyModifyGetOnOffCancel_OnOffClicked(object sender, EventArgs e)
        {
            this.ToggleSelection();
        }

        private void OkApplyModifyGetOnOffCancel_CancelClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okApplyModifyGetOnOffCancel1_Load(object sender, EventArgs e)
        {

        }

        private void saveLoad_Load(object sender, EventArgs e)
        {

        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            comboBox_ChimnyLayout.Items.Clear();
            comboBox_ChimnyLayout.Items.Add("Cylindrical");
            comboBox_ChimnyLayout.Items.Add("Conical");
            comboBox_ChimnyLayout.SelectedIndex = 0;

        }


        private void comboBox_ChimnyLayout_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ChimnyPictureBox.BackgroundImage = imageList1.Images[comboBox_ChimnyLayout.SelectedIndex];
            if (comboBox_ChimnyLayout.SelectedIndex == 1)
            {
                label_RadiusofTopRing.Visible = true;
                textBoxTopRadiusChinmy.Visible = true;
                label_RadiusofBottomRing.Text = "Diameter of Bottom Ring";
            }
            else
            {

                label_RadiusofTopRing.Visible = false;
                textBoxTopRadiusChinmy.Visible = false;
                label_RadiusofBottomRing.Text = "Diameter of Ring";

            }
        }
    }
}