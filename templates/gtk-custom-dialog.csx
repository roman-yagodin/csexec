#!/usr/bin/csexec -pkg:gtk-sharp-2.0

using System;

public class Program
{
    public static void Main (string [] args)
    {
        // init GTK application
        Gtk.Application.Init ();

        // create & show dialog
        var dialog = new CustomDialog ("Custom Dialog");
        dialog.Show ();

        // run main loop
        Gtk.Application.Run ();

        // handle response
        if (dialog.ResponseId == (int) Gtk.ResponseType.Ok)
        {
            Console.WriteLine ("Do something with '{0}'...", dialog.Text);
        }
    }
}

public class CustomDialog: Gtk.Dialog
{
    #region Widgets

    protected Gtk.Entry entry;

    #endregion

    #region Response

    public int ResponseId { get; protected set; }

    public string Text { get; protected set; }

    #endregion

    public CustomDialog (string title): base ()
    {
        Title = title;

        // add dialog buttons
        AddButton (Gtk.Stock.Cancel, Gtk.ResponseType.Cancel);
        AddButton (Gtk.Stock.Ok, Gtk.ResponseType.Ok);

        // create widgets
        entry = new Gtk.Entry ();
        VBox.PackStart (entry, true, false, 0);

        // wireup handlers
        Response += OnResponse;
        entry.Activated += OnEntryActivated;

        // show dialog
        ShowAll ();
    }

    protected void OnResponse (object o, Gtk.ResponseArgs a)
    {
        Text = entry.Text;
        ResponseId = (int) a.ResponseId;
        a.RetVal = true;

        Gtk.Application.Quit ();
    }

    void OnEntryActivated (object sender, EventArgs e)
	{
        Respond (Gtk.ResponseType.Ok);
	}
}
