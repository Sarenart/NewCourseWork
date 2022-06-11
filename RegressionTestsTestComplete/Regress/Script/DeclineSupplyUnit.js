function TestDeclineSupply()
{
  //Runs the "NewCourseWork" tested application.
  TestedApps.NewCourseWork.Run();
  //Clicks the 'Textbox' object.
  Aliases.NewCourseWork.HwndSource_RegWindow.RegWindow.Textbox.Click(178, 16);
  //Enters the text 'Tatiyana' in the 'Textbox' text editor.
  Aliases.NewCourseWork.HwndSource_RegWindow.RegWindow.Textbox.SetText("Tatiyana");
  //Clicks the 'passwordBox' object.
  Aliases.NewCourseWork.HwndSource_RegWindow.RegWindow.passwordBox.Click(125, 12);
  //Enters text in the 'passwordBox' text editor.
  Aliases.NewCourseWork.HwndSource_RegWindow.RegWindow.passwordBox.SetText(Project.Variables.Password1);
  //Clicks the 'Button' button.
  Aliases.NewCourseWork.HwndSource_RegWindow.RegWindow.Button.ClickButton();
  //Selects the 2 tab of the 'Navigation' tab control.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.ClickTab(2);
  //Selects the 3 tab of the 'Navigation' tab control.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.ClickTab(3);
  //Selects the 1 item of the 'CommodityWarehouseComboBox' combo box.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.CommodityWarehouseComboBox.ClickItem(1);
  //Clicks the 'FileAFormButtonCom' button.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.FileAFormButtonCom.ClickButton();
  //Selects the 1 item of the 'ComboBox' combo box.
  Aliases.NewCourseWork.HwndSource_FileAFormWindow.FileAFormWindow.ComboBox.ClickItem(1);
  //Rotates the mouse wheel to -1 over the 'Datagridcell320' object.
  Aliases.NewCourseWork.HwndSource_FileAFormWindow.FileAFormWindow.ProviderCommodities.Datagridcell320.MouseWheel(-1);
  //Rotates the mouse wheel to -2 over the 'Datagridcell5500' object.
  Aliases.NewCourseWork.HwndSource_FileAFormWindow.FileAFormWindow.ProviderCommodities.Datagridcell5500.MouseWheel(-2);
  //Rotates the mouse wheel to -1 over the 'Datagridcell2300' object.
  Aliases.NewCourseWork.HwndSource_FileAFormWindow.FileAFormWindow.ProviderCommodities.Datagridcell2300.MouseWheel(-1);
  //Clicks the 'Button' button.
  Aliases.NewCourseWork.HwndSource_FileAFormWindow.FileAFormWindow.ProviderCommodities.Button.ClickButton();
  //Clicks the 'IntegerUpDown' object.
  Aliases.NewCourseWork.HwndSource_FileAFormWindow.FileAFormWindow.FormCommodities.IntegerUpDown.Click(58, 9);
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
  //Checks whether the 'Text' property of the Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.ScrollViewer.Textblock object equals 'Статус - Заявка создана'.
  aqObject.CheckProperty(Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.ScrollViewer.Textblock, "Text", cmpEqual, "Статус - Заявка создана");
  //Clicks the 'Button' button.
  Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.Button.ClickButton();
  //Clicks the 'NonArrangedSupplies' grid cell at row 4, column 'Дата заявки'.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.NonArrangedSupplies.ClickCell(4, "Дата заявки");
  //Clicks the 'ArrangeSupplyButton' button.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.ArrangeSupplyButton.ClickButton();
  //Rotates the mouse wheel to -10 over the 'ScrollViewer' object.
  Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.ScrollViewer.MouseWheel(-10);
  //Sets the 'VScroll' scroll bar thumb to position 210,048571428571.
  Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.ScrollViewer.VScroll.Pos = 210.04857142857099;
  //Selects the 1 item of the 'Combobox' combo box.
  Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.ScrollViewer.Combobox.ClickItem(1);
  //Clicks the 'Button2' button.
  Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.Button2.ClickButton();
  //Clicks the 'btn_2' button.
  Aliases.NewCourseWork.dlg.btn_2.ClickButton();
  //Clicks the 'Button' button.
  Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.Button.ClickButton();
  //Clicks the 'NonArrangedSupplies' grid cell at row 4, column 'Статус'.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.NonArrangedSupplies.ClickCell(4, "Статус");
  //Clicks the 'ArrangeSupplyButton' button.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.ArrangeSupplyButton.ClickButton();
  //Rotates the mouse wheel to -9 over the 'ScrollViewer' object.
  Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.ScrollViewer.MouseWheel(-9);
  //Sets the 'VScroll' scroll bar thumb to position 210,048571428571.
  Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.ScrollViewer.VScroll.Pos = 210.04857142857099;
  //Selects the 2 item of the 'Combobox' combo box.
  Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.ScrollViewer.Combobox.ClickItem(2);
  //Clicks the 'Button2' button.
  Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.Button2.ClickButton();
  //Clicks the 'btn_2' button.
  Aliases.NewCourseWork.dlg.btn_2.ClickButton();
  //Clicks the 'Button' button.
  Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.Button.ClickButton();
  //Clicks the 'ShowAllSuppliesButton' button.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.ShowAllSuppliesButton.ClickButton();
  //Rotates the mouse wheel to -1 over the 'Datagridcell3' object.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.AllSupplies.Datagridcell3.MouseWheel(-1);
  //Rotates the mouse wheel to -1 over the 'DatagridcellCalyanLogistics' object.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.AllSupplies.DatagridcellCalyanLogistics.MouseWheel(-1);
  //Rotates the mouse wheel to -1 over the 'DatagridcellCalyanLogistics2' object.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.AllSupplies.DatagridcellCalyanLogistics2.MouseWheel(-1);
  //Clicks the 'AllSupplies' grid cell at row 12, column 'Поставщик'.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.AllSupplies.ClickCell(12, "Поставщик");
  //Clicks the 'ArrangeSupplyButton' button.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.ArrangeSupplyButton.ClickButton();
  //Checks whether the 'Text' property of the Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.ScrollViewer.Textblock4 object equals 'Статус - Поставка отменена'.
  aqObject.CheckProperty(Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.ScrollViewer.Textblock4, "Text", cmpEqual, "Статус - Поставка отменена");
  //Sets the 'VScroll' scroll bar thumb to position 210,048571428571.
  Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.ScrollViewer.VScroll.Pos = 210.04857142857099;
  //Clicks the 'Button' button.
  Aliases.NewCourseWork.HwndSource_SupplyUpdateWindow.SupplyUpdateWindow.Button.ClickButton();
  //Selects the 6 tab of the 'Navigation' tab control.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.ClickTab(6);
  //Clicks the 'Button2' button.
  Aliases.NewCourseWork.HwndSource_MainWindow.MainWindow.Navigation.Button2.ClickButton();
}