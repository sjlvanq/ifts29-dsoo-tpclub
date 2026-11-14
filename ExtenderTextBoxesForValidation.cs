using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Club1
{
    [ProvideProperty("AssociatedLabel", typeof(Control))]
    [ProvideProperty("ContainerTab", typeof(Control))]
    [ProvideProperty("IsRequired", typeof(Control))]
    public sealed class ExtenderTextBoxesForValidation: TextBox, IExtenderProvider
    {
        private readonly Dictionary<Control, ControlMetadata> _registry = new();
        public ExtenderTextBoxesForValidation()
        {
        }
        public ExtenderTextBoxesForValidation(IContainer container)
        {
            container.Add(this);
        }
        // Requerido por IExtenderProvider
        public bool CanExtend(object extendee)
        {
            return extendee is TextBox;
        }

        [Category("Metadata")]
        [DefaultValue(null)]
        public Label? GetAssociatedLabel(Control control) =>
            GetOrCreate(control).AssociatedLabel;

        public void SetAssociatedLabel(Control control, Label? label) =>
            GetOrCreate(control).AssociatedLabel = label;

        [Category("Metadata")]
        [DefaultValue(null)]
        public TabPage? GetContainerTab(Control control) =>
            GetOrCreate(control).ContainerTab;

        public void SetContainerTab(Control control, TabPage? tabPage) =>
            GetOrCreate(control).ContainerTab = tabPage;

        [Category("Validation")]
        [DefaultValue(false)]
        public bool GetIsRequired(Control control) =>
            GetOrCreate(control).IsRequired;

        public void SetIsRequired(Control control, bool isRequired) =>
            GetOrCreate(control).IsRequired = isRequired;

        public bool TryGetMetadata(Control control, out ControlMetadata? metadata) =>
            _registry.TryGetValue(control, out metadata);

        private ControlMetadata GetOrCreate(Control control)
        {
            if (!_registry.TryGetValue(control, out ControlMetadata? metadata))
            {
                metadata = new ControlMetadata();
                _registry[control] = metadata;
            }
            return metadata;
        }

        public bool ValidateAll(out Control? firstInvalidControl)
        {
            firstInvalidControl = null;

            foreach (KeyValuePair<Control, ControlMetadata> entry in _registry)
            {
                Control control = entry.Key;
                ControlMetadata metadata = entry.Value;

                if (metadata.AssociatedLabel is not null)
                {
                    metadata.AssociatedLabel.ForeColor = SystemColors.ControlText;
                }

                if (!metadata.IsRequired || HasValidValue(control))
                {
                    continue;
                }

                firstInvalidControl ??= control;

                if (metadata.AssociatedLabel is not null)
                {
                    metadata.AssociatedLabel.ForeColor = Color.Firebrick;
                }
            }

            if (firstInvalidControl is not null)
            {
                ControlMetadata failedMetadata = _registry[firstInvalidControl];
                if (failedMetadata.ContainerTab?.Parent is TabControl tabControl)
                {
                    tabControl.SelectedTab = failedMetadata.ContainerTab;
                }

                firstInvalidControl.Focus();
                return false;
            }

            return true;
        }

        private static bool HasValidValue(Control control)
        {
            return control switch
            {
                TextBox textBox => !string.IsNullOrWhiteSpace(textBox.Text),
                _ => true
            };
        }

        public sealed class ControlMetadata
        {
            public Label? AssociatedLabel { get; set; }
            public TabPage? ContainerTab { get; set; }
            public bool IsRequired { get; set; }
        }
    }
}
