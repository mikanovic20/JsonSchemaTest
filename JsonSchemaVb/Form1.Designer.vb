<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.tableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnGenerateJsonSchema = New System.Windows.Forms.Button()
        Me.btnReadJsonContents = New System.Windows.Forms.Button()
        Me.tableLayoutPanel1.SuspendLayout()
        Me.tableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.ColumnCount = 1
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel1.Controls.Add(Me.richTextBox1, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.tableLayoutPanel2, 0, 1)
        Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.tableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 2
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(394, 250)
        Me.tableLayoutPanel1.TabIndex = 3
        '
        'richTextBox1
        '
        Me.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.richTextBox1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.richTextBox1.Location = New System.Drawing.Point(3, 4)
        Me.richTextBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.richTextBox1.Name = "richTextBox1"
        Me.richTextBox1.ReadOnly = True
        Me.richTextBox1.Size = New System.Drawing.Size(388, 192)
        Me.richTextBox1.TabIndex = 1
        Me.richTextBox1.Text = ""
        '
        'tableLayoutPanel2
        '
        Me.tableLayoutPanel2.ColumnCount = 4
        Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140.0!))
        Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140.0!))
        Me.tableLayoutPanel2.Controls.Add(Me.btnGenerateJsonSchema, 2, 0)
        Me.tableLayoutPanel2.Controls.Add(Me.btnReadJsonContents, 3, 0)
        Me.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel2.Location = New System.Drawing.Point(3, 204)
        Me.tableLayoutPanel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tableLayoutPanel2.Name = "tableLayoutPanel2"
        Me.tableLayoutPanel2.RowCount = 1
        Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel2.Size = New System.Drawing.Size(388, 42)
        Me.tableLayoutPanel2.TabIndex = 2
        '
        'btnGenerateJsonSchema
        '
        Me.btnGenerateJsonSchema.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnGenerateJsonSchema.Location = New System.Drawing.Point(111, 5)
        Me.btnGenerateJsonSchema.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.btnGenerateJsonSchema.Name = "btnGenerateJsonSchema"
        Me.btnGenerateJsonSchema.Size = New System.Drawing.Size(134, 32)
        Me.btnGenerateJsonSchema.TabIndex = 0
        Me.btnGenerateJsonSchema.Text = "Generate Schema"
        Me.btnGenerateJsonSchema.UseVisualStyleBackColor = True
        '
        'btnReadJsonContents
        '
        Me.btnReadJsonContents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnReadJsonContents.Location = New System.Drawing.Point(251, 5)
        Me.btnReadJsonContents.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.btnReadJsonContents.Name = "btnReadJsonContents"
        Me.btnReadJsonContents.Size = New System.Drawing.Size(134, 32)
        Me.btnReadJsonContents.TabIndex = 0
        Me.btnReadJsonContents.Text = "Read Contents"
        Me.btnReadJsonContents.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 250)
        Me.Controls.Add(Me.tableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Form1"
        Me.Text = "JsonSchemaTest - VB.NET"
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.tableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents tableLayoutPanel1 As TableLayoutPanel
    Private WithEvents richTextBox1 As RichTextBox
    Private WithEvents tableLayoutPanel2 As TableLayoutPanel
    Private WithEvents btnGenerateJsonSchema As Button
    Private WithEvents btnReadJsonContents As Button
End Class
