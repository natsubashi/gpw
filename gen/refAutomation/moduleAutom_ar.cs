using System;
using System.Windows.Automation;

namespace moduleAUI {

class Program {
    static void Main(string[] args) {
        var tgtW = AutomationElement.RootElement.FindFirst(
            TreeScope.Children,
            new PropertyCondition(AutomationElement.NameProperty, "beInput"));
        if(tgtW != null) {
            AutomationElement tbx = tgtW.FindFirst(
                TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "textBox111"));

            if(tbx != null) {
                try {
                    var valuePattern = tbx.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;

                    if(valuePattern != null) {
                        valuePattern.SetValue("aWDA20109873a");
                    }
                }
                catch(Exception ex) { Console.WriteLine(ex); }
            }
        }
    }
}

}