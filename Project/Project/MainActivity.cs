using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace Project
{
    [Activity(Label = "LoginSystem", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button btnSignUp;
        private ProgressBar progressBar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            btnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);

            btnSignUp.Click += (object sender, EventArgs e) =>
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                DialogSignUp signUpDialog = new DialogSignUp();
                signUpDialog.Show(transaction, "dialog fragment");

                signUpDialog.OnSignUpComplete += SignUpDialog_OnSignUpComplete;    
            };

        }

        private void SignUpDialog_OnSignUpComplete(object sender, OnSignUpEventArgs e)
        {
            mProgressBar.Visibility = ViewStates.Visible;
            Thread thread = new Thread(ActLikeARequest);
            thread.Start();
            //string password = e.Password;
            //string fName = e.FirstName;
            //string email = e.Email;
        }

        private void ActLikeARequest()
        {
            Thread.Sleep(3000);

            RunOnUiThread(() => { mProgressBar.Visibility = ViewStates.Invisible; });
            int x = Resource.Animation.slide_right;
        }
    }
}

