using LibraryManagementSystem.App_Code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem.Pages.Memberships
{
    public partial class AddMembership1 : System.Web.UI.Page
    {
        string firstName = "";
        string lastName = "";
        //DateTime validFromDate = new DateTime();
        DateTime expirationDate = new DateTime();

        protected void Page_Load(object sender, EventArgs e)
        {
            ddlNationalities.Items[0].Attributes["disabled"] = "disabled";
            string selectedValue = ddlPhotos.SelectedValue;
            ShowPhotos();
            ddlPhotos.SelectedValue = selectedValue;
        }

        private void ShowPhotos()
        {
            //Get all filepaths
            string[] photos = Directory.GetFiles(Server.MapPath("~/Images/Members/"));

            //Get all filenames and add them to an arraylist
            ArrayList photoList = new ArrayList();

            foreach (string photo in photos)
            {
                string photoName = photo.Substring(photo.LastIndexOf(@"\") + 1);
                photoList.Add(photoName);
            }

            //Set the arrayList as the dropdownview's datasource and refresh
            ddlPhotos.DataSource = photoList;
            ddlPhotos.DataBind();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = Path.GetFileName(fileUploadPhotos.FileName);
                fileUploadPhotos.SaveAs(Server.MapPath("~/Images/Authors/") + fileName);
                lblUploadResult.Text = "Photo" + fileName + "has been succesfully uploaded!";
                Page_Load(sender, e);
            }
            catch (Exception)
            {
                lblUploadResult.Text = "Photo Upload failed!";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AppendMembership();
        }

        private void AppendMembership()
        {
            if (Page.IsValid)
            {
                try
                {
                    //Set values to basic member Info
                    int memberID = -1;
                    firstName = txtFirstName.Text;
                    lastName = txtLastName.Text;
                    string nationality = ddlNationalities.SelectedItem.Text;
                    string gender = radBtnListGender.SelectedValue;
                    DateTime birthDate = Convert.ToDateTime(txtDateOfBirth.Text);
                    string photo = ddlPhotos.SelectedValue;

                    //Set values to membership details
                    string libraryCardNo = txtLibraryCardNo.Text;
                    string membershipType = radBtnMembershipType.SelectedItem.Text;
                    DateTime validFromDate = Convert.ToDateTime(txtValidFromDate.Text);
                    DateTime expirationDate = Convert.ToDateTime(txtExpirationDate.Text);

                    //Set values to member's contct Info
                    string phone = txtPhone.Text;
                    string email = txtEmail.Text;
                    string address = txtAddress.Text;

                    //Creates an instance of Member class
                    Member member = new Member(firstName, lastName, nationality, gender,
                                                birthDate, photo, phone, email, address);

                    if (!member.CheckIfMemberExists(firstName, lastName))
                    {
                        //Calls a method in the class to append a new Member
                        memberID = member.AddMember(member);

                        //Creates an instance of Membership class & Adds a new Membership into database
                        Membership membership = new Membership(memberID, libraryCardNo, membershipType, validFromDate, expirationDate);
                        membership.AddMembership(membership);

                        lblMemberName.Text = firstName + " " + lastName +" ";
                        lblcardNumber.Text = txtLibraryCardNo.Text;
                        divSuccess.Visible = true;
                        ClearTextFields();
                    }

                    else
                    {
                        //Shows a mesage says that this member has been already appended into database
                        member = null;
                        divFail.Visible = true;
                     
                    }

                    btnSave.Enabled = false;

                }
                catch (Exception)
                {
                    //Shows an Error mesage says that something went wrong
                }
            }
        }

        private void ClearTextFields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtDateOfBirth.Text = "";
            ddlNationalities.SelectedIndex = 0;
            ddlPhotos.SelectedIndex = 0;
            txtLibraryCardNo.Text = "";
            radBtnMembershipType.SelectedIndex = 0;
            txtValidFromDate.Text = "";
            txtExpirationDate.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
        }

        protected void btnGenerateCardNo_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int num = random.Next(10000);
            txtLibraryCardNo.Text = txtFirstName.Text.Substring(0, 3) + txtLastName.Text.Substring(0, 3) + num;
            txtLibraryCardNo.Enabled = true;
        }


        protected void txtValidFromDate_TextChanged(object sender, EventArgs e)
        {
            txtExpirationDate.Enabled = true;

            if (radBtnListMembershipDuration.SelectedIndex == 0)
            {
                if (txtValidFromDate.Text != string.Empty)
                {
                    expirationDate = Convert.ToDateTime(txtValidFromDate.Text).AddDays(180);
                    txtExpirationDate.Text = expirationDate.ToString("MMM dd, yyyy");
                }
            }

            if (radBtnListMembershipDuration.SelectedIndex == 1)
            {
                if (txtValidFromDate.Text != string.Empty)
                {
                    expirationDate = Convert.ToDateTime(txtValidFromDate.Text).AddDays(365);
                    txtExpirationDate.Text = expirationDate.ToString("MMM dd, yyyy");
                }
            }

            if (radBtnListMembershipDuration.SelectedIndex == 2)
            {
                if (txtValidFromDate.Text != string.Empty)
                {
                    expirationDate = Convert.ToDateTime(txtValidFromDate.Text).AddDays(545);
                    txtExpirationDate.Text = expirationDate.ToString("MMM dd, yyyy");
                }
            }

            if (radBtnListMembershipDuration.SelectedIndex == 3)
            {
                if (txtValidFromDate.Text != string.Empty)
                {
                    expirationDate = Convert.ToDateTime(txtValidFromDate.Text).AddDays(730);
                    txtExpirationDate.Text = expirationDate.ToString("MMM dd, yyyy");
                }
            }
        }


        protected void radBtnListMembershipDuration_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}