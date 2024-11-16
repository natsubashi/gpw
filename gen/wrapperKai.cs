using System;
using System.Text;
using System.Diagnostics;
using System.Windows.Automation;
using System.Threading;

class Program {
    private static AutomationElement FindWindowByTitle(string windowTitle) {
        AutomationElement window = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, windowTitle));
        if (window != null) return window;
        return null;
    }

    private static AutomationElement FindTextBox(AutomationElement parent, string automationID){
        AutomationElement textBox = parent.FindFirst(
            TreeScope.Descendants,
            new PropertyCondition(AutomationElement.AutomationIdProperty, automationID));
        return textBox;
    }

    static void Main(string[] args) {
        var cnd = new PropertyCondition(AutomationElement.NameProperty, "beInput");
        var apliElement = AutomationElement.RootElement.FindFirst(TreeScope.Children, cnd);

        Console.WriteLine(apliElement.GetCurrentPropertyValue(AutomationElement.ClassNameProperty));
        Console.WriteLine(FindTextBox(apliElement, "textBox111").GetCurrentPropertyValue(AutomationElement.AutomationIdProperty));

        var tb111 = FindTextBox(apliElement, "textBox111");
        ValuePattern editValue = tb111.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
        Thread.Sleep(1000);
        editValue.SetValue("WD!2aa0");
    }
}
