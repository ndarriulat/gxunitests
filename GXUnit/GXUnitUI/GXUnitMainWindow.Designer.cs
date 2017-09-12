using PGGXUnit.Packages.GXUnit.GeneXusAPI;
namespace PGGXUnit.Packages.GXUnit.GXUnitUI
{
    partial class GXUnitMainWindow
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SuitesTreeCMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoTestCaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuild = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.checkSelectAll = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuitesTree = new System.Windows.Forms.TreeView();
            this.SuitesTreeCMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SuitesTreeCMenu
            // 
            this.SuitesTreeCMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem});
            this.SuitesTreeCMenu.Name = "SuitesTreeCMenu";
            this.SuitesTreeCMenu.Size = new System.Drawing.Size(152, 26);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.nuevoToolStripMenuItem.Text = "New Test Suite";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevaTestSuiteToolStripMenuItem_Click);
            // 
            // nuevoTestCaseToolStripMenuItem
            // 
            this.nuevoTestCaseToolStripMenuItem.Name = "nuevoTestCaseToolStripMenuItem";
            this.nuevoTestCaseToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.nuevoTestCaseToolStripMenuItem.Text = "New Test Case";
            this.nuevoTestCaseToolStripMenuItem.Click += new System.EventHandler(this.nuevoTestCaseToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.eliminarToolStripMenuItem.Text = "Delete";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarTestSuiteToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBuild);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 354);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 35);
            this.panel1.TabIndex = 28;
            // 
            // btnBuild
            // 
            this.btnBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuild.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuild.Location = new System.Drawing.Point(189, 6);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(86, 23);
            this.btnBuild.TabIndex = 0;
            this.btnBuild.Text = "Test";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnUpdate);
            this.panel3.Controls.Add(this.checkSelectAll);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(278, 35);
            this.panel3.TabIndex = 30;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Image = global::PGGXUnit.Packages.GXUnit.Items.UpdatePng;
            this.btnUpdate.Location = new System.Drawing.Point(250, 6);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(25, 23);
            this.btnUpdate.TabIndex = 29;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // checkSelectAll
            // 
            this.checkSelectAll.AutoSize = true;
            this.checkSelectAll.Location = new System.Drawing.Point(3, 10);
            this.checkSelectAll.Name = "checkSelectAll";
            this.checkSelectAll.Size = new System.Drawing.Size(117, 17);
            this.checkSelectAll.TabIndex = 28;
            this.checkSelectAll.Text = "Select/Unselect All";
            this.checkSelectAll.UseVisualStyleBackColor = true;
            this.checkSelectAll.Click += new System.EventHandler(this.checkSelectAll_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SuitesTree);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(278, 319);
            this.panel2.TabIndex = 31;
            // 
            // SuitesTree
            // 
            this.SuitesTree.AllowDrop = true;
            this.SuitesTree.BackColor = System.Drawing.Color.White;
            this.SuitesTree.CheckBoxes = true;
            this.SuitesTree.ContextMenuStrip = this.SuitesTreeCMenu;
            this.SuitesTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SuitesTree.Location = new System.Drawing.Point(0, 0);
            this.SuitesTree.Name = "SuitesTree";
            this.SuitesTree.Size = new System.Drawing.Size(278, 319);
            this.SuitesTree.TabIndex = 3;
            this.SuitesTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.SuitesTree_AfterCheck);
            this.SuitesTree.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.SuitesTree_ItemDrag);
            this.SuitesTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.SuitesTree_NodeMouseClick);
            this.SuitesTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.SuitesTree_DragDrop);
            this.SuitesTree.DragEnter += new System.Windows.Forms.DragEventHandler(this.SuitesTree_DragEnter);
            this.SuitesTree.DragOver += new System.Windows.Forms.DragEventHandler(this.SuitesTree_DragOver);
            this.SuitesTree.DoubleClick += new System.EventHandler(this.SuitesTree_NodeMouseDoubleClick);
            this.SuitesTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SuitesTree_MouseDown);
            // 
            // GXUnitMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "GXUnitMainWindow";
            this.Size = new System.Drawing.Size(278, 389);
            this.SuitesTreeCMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip SuitesTreeCMenu;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoTestCaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.CheckBox checkSelectAll;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView SuitesTree;
    }
}
