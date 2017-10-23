﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Capture.Workflow.Core.Classes;
using Capture.Workflow.Core.Classes.Attributes;
using Capture.Workflow.Core.Interface;

namespace Capture.Workflow.Plugins.Commands
{
    [Description("")]
    [PluginType(PluginType.Command)]
    [DisplayName("ShowMessage")]
    public class ShowMessageAction : BaseCommand, IWorkflowCommand
    {
        public WorkFlowCommand CreateCommand()
        {
            var command = GetCommand();
            command.Properties.Add(new CustomProperty()
            {
                Name = "Message",
                PropertyType = CustomPropertyType.String
            });
            command.Properties.Add(new CustomProperty()
            {
                Name = "Error",
                PropertyType = CustomPropertyType.Bool
            });
            return command;
        }

        public bool Execute(WorkFlowCommand command, Context context)
        {
            if (!CheckCondition(command, context))
                return true;
            if (!string.IsNullOrEmpty(command.Properties["Message"].ToString(context)))
                MessageBox.Show(command.Properties["Message"].ToString(context));
            return !command.Properties["Error"].ToBool(context);
        }
    }
}

