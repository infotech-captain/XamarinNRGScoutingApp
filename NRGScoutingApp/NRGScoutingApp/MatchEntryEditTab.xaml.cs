﻿using System;
using System.Collections.Generic;
using System.Collections;
using Xamarin.Forms;

namespace NRGScoutingApp
{
    public partial class MatchEntryEditTab : TabbedPage
    {
        public MatchEntryEditTab()
        {
            Children.Add(new NewMatchStart());
            Children.Add(new MatchEvents());
            if (checkParse()){
                Children.Add(new MatchParameters(vals));
            }
            else{
                Children.Add(new MatchParameters());
            }
            BindingContext = this;
            App.Current.Properties["newAppear"] = 1;
            App.Current.SavePropertiesAsync();
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
        }
        ArrayList vals = new ArrayList();
        string titleName = (App.Current.Properties["teamStart"].ToString());
        public string teamName { get { return titleName; } }

        private Boolean checkParse(){
            if (!App.Current.Properties.ContainsKey(App.Current.Properties["teamStart"].ToString() + "converted")) { 
                return false; 
            }
            else{
                ParametersFormat s = new ParametersFormat();
                vals = ParametersFormat.ParseMatchParam(App.Current.Properties[App.Current.Properties["teamStart"].ToString() + "converted"].ToString()); //"<" + App.Current.Properties["teamStart"].ToString()+">"
                DisplayAlert("Hello", "exists", "ok");  //DEBUG
                return true;
            }
        }
    }
}