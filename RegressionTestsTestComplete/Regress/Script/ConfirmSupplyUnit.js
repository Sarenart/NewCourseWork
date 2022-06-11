function TestConfirmSupply()
{
  //Runs the "NewCourseWork" tested application.
  TestedApps.NewCourseWork.Run();
  //Clicks the 'Textbox' object.
  Aliases.NewCourseWork.HwndSource_RegWindow.RegWindow.Textbox.Click(85, 16);
  //Enters the text '' in the 'Textbox' text editor.
  Aliases.NewCourseWork.HwndSource_RegWindow.RegWindow.Textbox.SetText("");
  //Enters '!~[ReleaseLast][ReleaseLast]' in the 'Textbox' object.
  Aliases.NewCourseWork.HwndSource_RegWindow.RegWindow.Textbox.Keys("!~[ReleaseLast][ReleaseLast]");
  //Enters the text 'Tatiyana' in the 'Textbox' text editor.
  Aliases.NewCourseWork.HwndSource_RegWindow.RegWindow.Textbox.SetText("Tatiyana");
  //Clicks the 'passwordBox' object.
  Aliases.NewCourseWork.HwndSource_RegWindow.RegWindow.passwordBox.Click(191, 12);
  //Enters text in the 'passwordBox' text editor.
  Aliases.NewCourseWork.HwndSource_RegWindow.RegWindow.passwordBox.SetText(Project.Variables.Password1);
  //Clicks the 'Button' button.
  Aliases.NewCourseWork.HwndSource_RegWindow.RegWindow.Button.ClickButton();
  //Selects the 3 tab of the 'Navigation' tab control.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.ClickTab(3);
  //Selects the 1 item of the 'CommodityWarehouseComboBox' combo box.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.CommodityWarehouseComboBox.ClickItem(1);
  //Clicks the 'FileAFormButtonCom' button.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.FileAFormButtonCom.ClickButton();
  //Selects the 1 item of the 'ComboBox' combo box.
  Aliases.NewCourseWork.HwndSource_FileAFormWindow.FileAFormWindow.ComboBox.ClickItem(1);
  //Rotates the mouse wheel to -1 over the 'Datagridcell380' object.
  Aliases.NewCourseWork.HwndSource_FileAFormWindow.FileAFormWindow.ProviderCommodities.Datagridcell380.MouseWheel(-1);
  //Rotates the mouse wheel to -1 over the 'Datagridcell520' object.
  Aliases.NewCourseWork.HwndSource_FileAFormWindow.FileAFormWindow.ProviderCommodities.Datagridcell520.MouseWheel(-1);
  //Clicks the 'Button2' button.
  Aliases.NewCourseWork.HwndSource_FileAFormWindow.FileAFormWindow.ProviderCommodities.Button2.ClickButton();
  //Clicks the 'IntegerUpDown' object.
  Aliases.NewCourseWork.HwndSource_FileAFormWindow.FileAFormWindow.FormCommodities.IntegerUpDown.Click(64, 10);
  //Selects the 1 item of the 'ComboBox2' combo box.
  Aliases.NewCourseWork.HwndSource_FileAFormWindow.FileAFormWindow.ComboBox2.ClickItem(1);
  //Clicks the 'Button' button.
  Aliases.NewCourseWork.HwndSource_FileAFormWindow.FileAFormWindow.Button.ClickButton();
  //Clicks the 'btn_' button.
  Aliases.NewCourseWork.dlg.btn_.ClickButton();
  //Clicks the 'btn_' button.
  Aliases.NewCourseWork.dlg.btn_.ClickButton();
  //Clicks the 'Button2' button.
  Aliases.NewCourseWork.HwndSource_FileAFormWindow.FileAFormWindow.Button2.ClickButton();
  //Selects the 2 tab of the 'Navigation' tab control.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.ClickTab(2);
  //Selects the 1 item of the 'SupplyWarehouseComboBox' combo box.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.SupplyWarehouseComboBox.ClickItem(1);
  //Clicks the 'NonArrangedSupplies' grid cell at row 4, column 'Поставщик'.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.NonArrangedSupplies.ClickCell(4, "Поставщик");
  //Clicks the 'ArrangeSupplyButton' button.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.ArrangeSupplyButton.ClickButton();
  //Rotates the mouse wheel to -4 over the 'ScrollViewer' object.
  Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.ScrollViewer.MouseWheel(-4);
  //Sets the 'VScroll' scroll bar thumb to position 192.
  Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.ScrollViewer.VScroll.Pos = 192;
  //Selects the 1 item of the 'Combobox' combo box.
  Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.ScrollViewer.Combobox.ClickItem(1);
  //Rotates the mouse wheel to 3 over the 'ScrollViewer' object.
  Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.ScrollViewer.MouseWheel(3);
  //Checks whether the 'Text' property of the Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.ScrollViewer.Textblock object equals 'Статус - Заявка создана'.
  aqObject.CheckProperty(Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.ScrollViewer.Textblock, "Text", cmpEqual, "Статус - Заявка создана");
  //Rotates the mouse wheel to -1 over the 'ScrollViewer' object.
  Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.ScrollViewer.MouseWheel(-1);
  //Clicks the 'Button2' button.
  Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.Button2.ClickButton();
  //Clicks the 'btn_2' button.
  Aliases.NewCourseWork.dlg.btn_2.ClickButton();
  //Sets the 'VScroll' scroll bar thumb to position 210,048571428571.
  Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.ScrollViewer.VScroll.Pos = 210.04857142857099;
  //Clicks the 'Combobox' object.
  Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.ScrollViewer.Combobox.Click(156, 15);
  //Selects the 0 item of the 'Combobox' combo box.
  Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.ScrollViewer.Combobox.ClickItem(0);
  //Clicks the 'Button2' button.
  Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.Button2.ClickButton();
  //Clicks the 'btn_2' button.
  Aliases.NewCourseWork.dlg.btn_2.ClickButton();
  //Clicks the 'btn_' button.
  Aliases.NewCourseWork.dlg.btn_.ClickButton();
  //Closes the 'HwndSource_SupplyUpdateWindow' window.
  Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.Close();
  //Clicks the 'ShowAllSuppliesButton' button.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.ShowAllSuppliesButton.ClickButton();
  //Rotates the mouse wheel to -1 over the 'Datagridcell' object.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.AllSupplies.Datagridcell.MouseWheel(-1);
  //Rotates the mouse wheel to -1 over the 'Datagridcell2' object.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.AllSupplies.Datagridcell2.MouseWheel(-1);
  //Clicks the 'AllSupplies' grid cell at row 11, column 'Поставщик'.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.AllSupplies.ClickCell(11, "Поставщик");
  //Clicks the 'ArrangeSupplyButton' button.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.ArrangeSupplyButton.ClickButton();
  //Rotates the mouse wheel to -2 over the 'ScrollViewer' object.
  Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.ScrollViewer.MouseWheel(-2);
  //Checks whether the 'WPFControlText' property of the Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.ScrollViewer.Textblock3 object equals 'Статус - Поставка оформлена'.
  aqObject.CheckProperty(Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.ScrollViewer.Textblock3, "WPFControlText", cmpEqual, "Статус - Поставка оформлена");
  //Clicks the 'Button' button.
  Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.Button.ClickButton();
  //Selects the 6 tab of the 'Navigation' tab control.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.ClickTab(6);
  //Clicks the 'Button2' button.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.Button2.ClickButton();
}