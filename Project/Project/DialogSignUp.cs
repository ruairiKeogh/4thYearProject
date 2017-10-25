using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Project
{
    
    public class OnSignUpEventArgs : EventArgs
    {
        private string firstName;
        private string email;
        private string password;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public OnSignUpEventArgs(string firstName, string email, string password) : base()
        {
            FirstName = firstName;
            Email = email;
            Password = password;
        }
    }

    class DialogSignUp : DialogFragment
    {
        private EditText txtFirstName;
        private EditText txtEmail;
        private EditText txtPassword;
        private Button btnSignUp;

        public event EventHandler<OnSignUpEventArgs> OnSignUpComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_sign_up, container, false);

            txtFirstName = view.FindViewById<EditText>(Resource.Id.txtFirstName);
            txtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            txtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            btnSignUp = view.FindViewById<Button>(Resource.Id.btnDialogEmail);

            btnSignUp.Click += btnSignUp_Click;

            return view;
        }

        void btnSignUp_Click(object sender, EventArgs e)
        {
            //User has clicked the sign up button
            OnSignUpComplete.Invoke(this, new OnSignUpEventArgs(txtFirstName.Text, txtEmail.Text, txtPassword.Text));
            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); //Sets the title bar to invisible
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation; //set the animation
        }
    }
}