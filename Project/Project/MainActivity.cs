using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Threading;
using Android.Views;

namespace Project
{
    [Activity(Label = "LoginSystem", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button btnSignUp;
        private Button btnSignIn;
        private ProgressBar progressBar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            btnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            btnSignIn = FindViewById<Button>(Resource.Id.btnSignIn);
            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);

            btnSignUp.Click += (object sender, EventArgs e) =>
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                DialogSignUp signUpDialog = new DialogSignUp();
                signUpDialog.Show(transaction, "dialog fragment");

                signUpDialog.OnSignUpComplete += SignUpDialog_OnSignUpComplete;    
            };

            btnSignIn.Click += (object sender, EventArgs e) =>
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                DialogSignIn signInDialog = new DialogSignIn();
                signInDialog.Show(transaction, "dialog fragment");

                signInDialog.OnSignInComplete += SignInDialog_OnSignInComplete;
            };
        }

        private void SignUpDialog_OnSignUpComplete(object sender, OnSignUpEventArgs e)
        {
            progressBar.Visibility = ViewStates.Visible;
            //Code for database
            string password = e.Password;
            string fName = e.FirstName;
            string email = e.Email;
        }

        private void SignInDialog_OnSignInComplete(object sender, OnSignInEventArgs e)
        {
            progressBar.Visibility = ViewStates.Visible;
            string password = e.Password;
            string email = e.Email;
        }

    }
}

