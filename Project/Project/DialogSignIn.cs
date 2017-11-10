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
    public class OnSignInEventArgs : EventArgs
    {
        private string email;
        private string password;

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

        public OnSignInEventArgs(string email, string password) : base()
        {
            Email = email;
            Password = password;
        }
    }

    class DialogSignIn : DialogFragment
    {
        private EditText txtEmail;
        private EditText txtPassword;
        private Button btnSignIn;

        public event EventHandler<OnSignInEventArgs> OnSignInComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_sign_in, container, false);

            txtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            txtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            btnSignIn = view.FindViewById<Button>(Resource.Id.btnDialogEmail);

            btnSignIn.Click += btnSignIn_Click;

            return view;
        }

        void btnSignIn_Click(object sender, EventArgs e)
        {
            //User has clicked the sign up button
           
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); //Sets the title bar to invisible
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation; //set the animation
        }
    }
}
