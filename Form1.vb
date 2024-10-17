Public Class Form1
    Dim numero As Integer ' Numero (chiffre) de 0 à 9

    'actions qui ont lieu lorsque l'on appuie sur un opérateur mathématique (+,-,*,/)
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click, Button1.Click, Button2.Click, Button3.Click
        'Obtenir le nombre présent et ajouter l'opérateur dans la zone de texte (l'écran)
        Dim currentNum As Double
        If Double.TryParse(TextBox1.Text, currentNum) = False Then
            'Erreur, le nombre n'est pas valide
        End If
        Dim btn As Button = DirectCast(sender, Button)
        TextBox1.Text += btn.Text
    End Sub

    'ajoute 0 à l'écran
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        numero = 0
        TextBox1.Text = TextBox1.Text & numero
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    'ajoute 1 à l'écran
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        numero = 1
        TextBox1.Text = TextBox1.Text & numero
    End Sub

    'ajoute 2 à l'écran
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        numero = 2
        TextBox1.Text = TextBox1.Text & numero
    End Sub

    'ajoute 3 à l'écran
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        numero = 3
        TextBox1.Text = TextBox1.Text & numero
    End Sub

    'ajoute 4 à l'écran
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        numero = 4
        TextBox1.Text = TextBox1.Text & numero
    End Sub

    'ajoute 5 à l'écran
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        numero = 5
        TextBox1.Text = TextBox1.Text & numero
    End Sub

    'ajoute 6 à l'écran
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        numero = 6
        TextBox1.Text = TextBox1.Text & numero
    End Sub

    'ajoute 7 à l'écran
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        numero = 7
        TextBox1.Text = TextBox1.Text & numero
    End Sub

    'ajoute 8 à l'écran
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        numero = 8
        TextBox1.Text = TextBox1.Text & numero
    End Sub

    'ajoute 9 à l'écran
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        numero = 9
        TextBox1.Text = TextBox1.Text & numero
    End Sub

    'Bouton Clear, tout est effacé
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        ' Efface le contenu du TextBox
        TextBox1.Clear()
    End Sub

    'Bouton " = "
    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        'sépare les entrées (d'un côté les opérateurs, de l'autre les nombres)
        Dim iString As String = TextBox1.Text ' on récupère la chaine de caractère du TextBox
        Dim list As New List(Of String) ' On crée une liste 
        Dim currentString As String = ""
        For Each c As Char In iString 'on va regarder chaque entrée pour savoir si on les met en temps qu'opérateur ou que nombre
            If Char.IsDigit(c) Then
                currentString += c 'on ajoute le caractère dans currentString si c'est un chiffre
            Else 'si il ne s'agit pas d'un chiffre
                If currentString <> "" Then 'si le currentString n'est pas vide, on l'ajoute dans la liste et vide currentString
                    list.Add(currentString)
                    currentString = ""
                End If
                list.Add(c.ToString()) 'si currentString vide, on ajoute l'entrée dans list
            End If
        Next 'fin de la boucle 
        If currentString <> "" Then 'si currentString pas vide, on l'ajoute dans list
            list.Add(currentString)
        End If

        Dim res As Double = 0 ' resultat de notre calcul
        Dim currentOperator As String = "+"
        For i As Integer = 0 To list.Count - 1 ' Boucle pour chaque element de la liste qu'on a stocké précedemment
            Dim n As String = list(i) ' Recupère l'element n (de type string) de la liste
            ' on verifie si c'est un chiffre numérique
            If IsNumeric(n) Then
                Dim num As Double = Double.Parse(n)
                If num = 0 AndAlso n.Length > 1 Then ' empêche la suite de Zero si on commence avec un Zero
                    MessageBox.Show("Error")
                    Return
                End If
                ' Calcule le resultat en fonction de l'opération
                Select Case currentOperator
                    Case "+"
                        res += num ' additionne
                    Case "-"
                        res -= num ' soustrait
                    Case "*"
                        res *= num ' multiplie
                    Case "/"
                        res /= num ' divise
                End Select
            Else
                currentOperator = n ' recupère le type de l'opération
            End If
        Next

        ' Affichage du résultat sur l'écran
        TextBox1.Text = res.ToString()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

End Class
