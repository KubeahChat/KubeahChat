﻿/*
 * Kubeah ! Open Source Project
 * 
 * Kubeah Chat
 * Just like Open Source
 * 
 * for more informations about Kubeah Chat
 * Please visit https://github.com/CrBast/KubeahChat
 * 
 * APPLICATION LICENSE
 * GNU General Public License v3.0
 * https://github.com/CrBast/KubeahChat/blob/master/LICENSE
 * */
using KChat.Methods;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace KChat
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }
        Dictionary<string, string> dict = new Dictionary<string, string>();

        private void frmConfig_Load(object sender, EventArgs e)
        {
            //Display all settings with App.config
            var temp = "";
            temp = XmlManipulation.GetValue("FocusActivate");
            if (temp == "") { }
            else
            {
                if (temp == "ON")
                    chbFocusOn.Checked = true;
                else
                    chbFocusOff.Checked = true;
            }
            
            temp = XmlManipulation.GetValue("EnableLastIpConnexion");
            if (temp == "") { }
            else
            {
                if (temp == "ON")
                    chbLastIpRecipientOn.Checked = true;
                else
                    chbLastIpRecipientOff.Checked = true;
            }

            temp = XmlManipulation.GetValue("SaveDiscussion");
            if (temp == "") { }
            else
            {
                if (temp == "ON")
                    chbSaveDiscussionOn.Checked = true;
                else
                    chbSaveDiscussionOff.Checked = true;
            }

            temp = XmlManipulation.GetValue("NotificationsEnable");
            if (temp == "") { }
            else
            {
                if (temp == "ON")
                    chbEnableNotificationsOn.Checked = true;
                else
                    chbEnableNotificationsOff.Checked = true;
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chbFocusOn_CheckedChanged(object sender, EventArgs e)
        {
            //Management Checked - not checked
            if(chbFocusOn.Checked == false && chbFocusOff.Checked == false)
            {
                chbFocusOff.Checked = true;
            }
            if(chbFocusOn.Checked == true)
            {
                chbFocusOff.Checked = false;
                //Change value on App.config
                XmlManipulation.ModifyElementXml("FocusActivate", "ON");
            }
        }

        private void chbFocusOff_CheckedChanged(object sender, EventArgs e)
        {
            //Management Checked - not checked
            if (chbFocusOn.Checked == false && chbFocusOff.Checked == false)
            {
                chbFocusOn.Checked = true;
            }
            if (chbFocusOff.Checked == true)
            {
                chbFocusOn.Checked = false;
                //Change value on App.config
                XmlManipulation.ModifyElementXml("FocusActivate", "OFF");
            }
        }

        private void chbLastIpRecipientOn_CheckedChanged(object sender, EventArgs e)
        {
            //Management Checked - not checked
            if (chbLastIpRecipientOn.Checked == false && chbLastIpRecipientOff.Checked == false)
            {
                chbLastIpRecipientOff.Checked = true;
            }
            if (chbLastIpRecipientOn.Checked == true)
            {
                chbLastIpRecipientOff.Checked = false;
                //Change value on App.config
                XmlManipulation.ModifyElementXml("EnableLastIpConnexion", "ON");
            }           
        }

        private void chbLastIpRecipientOff_CheckedChanged(object sender, EventArgs e)
        {
            //Management Checked - not checked
            if (chbLastIpRecipientOn.Checked == false && chbLastIpRecipientOff.Checked == false)
            {
                chbLastIpRecipientOn.Checked = true;
            }
            if (chbLastIpRecipientOff.Checked == true)
            {
                chbLastIpRecipientOn.Checked = false;
                //Change value on App.config
                XmlManipulation.ModifyElementXml("EnableLastIpConnexion", "OFF");
                XmlManipulation.ModifyElementXml("LastIpConnexion", "");
            }
        }

        private void lblDropDiscussion_MouseHover(object sender, EventArgs e)
        {
            lblDropDiscussion.BackColor = Color.Red;
        }

        private void lblDropDiscussion_MouseLeave(object sender, EventArgs e)
        {
            lblDropDiscussion.BackColor = Color.Transparent;
        }

        private void lblDropDiscussion_Click(object sender, EventArgs e)
        {
            lblDropDiscussion.BackColor = Color.Transparent;
            if(Directory.Exists("./Discussions"))
            {
                //If the directory exist all file is deleted
                var di = new DirectoryInfo("./Discussions");
                foreach (var file in di.GetFiles())
                    file.Delete();
                foreach (var dir in di.GetDirectories())
                    dir.Delete(true);
            }
            Objects.KNotification.Show("All discussions have been deleted.");
        }

        private void chbSaveDiscussionOn_CheckedChanged(object sender, EventArgs e)
        {
            //Management Checked - not checked
            if (chbSaveDiscussionOn.Checked == false && chbSaveDiscussionOff.Checked == false)
            {
                chbSaveDiscussionOff.Checked = true;
            }
            if (chbSaveDiscussionOn.Checked == true)
            {
                chbSaveDiscussionOff.Checked = false;
                //Change value on App.config
                XmlManipulation.ModifyElementXml("SaveDiscussion", "ON");
            }
        }

        private void chbSaveDiscussionOff_CheckedChanged(object sender, EventArgs e)
        {
            //Management Checked - not checked
            if (chbSaveDiscussionOn.Checked == false && chbSaveDiscussionOff.Checked == false)
            {
                chbSaveDiscussionOn.Checked = true;
            }
            if (chbSaveDiscussionOff.Checked == true)
            {
                chbSaveDiscussionOn.Checked = false;
                //Change value on App.config
                XmlManipulation.ModifyElementXml("SaveDiscussion", "OFF");
            }
            // Objects.KNotification.Show("The saving of discussions is cancelled.\r\n!!! Old backups are not deleted !!!");
        }

        private void chbEnableNotificationsOn_CheckedChanged(object sender, EventArgs e)
        {
            //Management Checked - not checked
            if (chbEnableNotificationsOn.Checked == false && chbEnableNotificationsOff.Checked == false)
            {
                chbEnableNotificationsOff.Checked = true;
            }
            if (chbEnableNotificationsOn.Checked == true)
            {
                chbEnableNotificationsOff.Checked = false;
                //Change value on App.config
                XmlManipulation.ModifyElementXml("NotificationsEnable", "ON");
            }
        }

        private void chbEnableNotificationsOff_CheckedChanged(object sender, EventArgs e)
        {
            //Management Checked - not checked
            if (chbEnableNotificationsOn.Checked == false && chbEnableNotificationsOff.Checked == false)
            {
                chbEnableNotificationsOn.Checked = true;
            }
            if (chbEnableNotificationsOff.Checked == true)
            {
                chbEnableNotificationsOn.Checked = false;
                //Change value on App.config
                XmlManipulation.ModifyElementXml("NotificationsEnable", "OFF");
            }
        }
    }
}
