#!/usr/bin/csexec -pkg:gtk-sharp-2.0

using System;

public class Program
{
    public static void Main (string [] args)
    {
        // init GTK application
        Gtk.Application.Init ();

        // create & show dialog
        var dialog = new Gtk.MessageDialog (null, 0, Gtk.MessageType.Info, Gtk.ButtonsType.OkCancel, "Hello, {0}!", "World");
        dialog.Title = "Message Dialog";
        var responseId = 0;
        dialog.Response += (object o, Gtk.ResponseArgs a) => {
            responseId = (int) a.ResponseId; Gtk.Application.Quit ();
        };
        dialog.Show ();

        // run main loop
        Gtk.Application.Run ();

        // handle response
        if (responseId == (int) Gtk.ResponseType.Ok)
        {
            Console.WriteLine ("Do something...");
        }
    }
}
