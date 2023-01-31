Imports System.Text.RegularExpressions

Public Class Form1

    Dim check As Integer

    'gebruikersnaam spatie checker
    Public Function validateGebruikersnaam(ByVal pass As String) As Boolean
        Dim pattern As String = " "


        Dim patternRegex As Match = Regex.Match(pass, pattern)

        Return (patternRegex.Success)
    End Function

    'sign checker
    Public Function validatePassword(ByVal pass As String) As Boolean
        Dim pattern As String = "[~`!@#$%^&*()-_=+';:,./<>?]"


        Dim patternRegex As Match = Regex.Match(pass, pattern)

        Return (patternRegex.Success)
    End Function

    'pass length checker
    Public Function validatePasswordAmount(ByVal pass As String) As Boolean
        Dim MinimumPasswordLength As Integer = 8
        Dim myChars() As Char = pass.ToCharArray()
        Dim nmr As Integer = 0
        For Each ch As Char In myChars

            nmr += 1

        Next

        If nmr < 8 Then
            Return False
        Else
            Return True
        End If

    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'passwoord
        Dim nmr As Integer = 0
        Dim sgn As Integer = 0
        Dim pass As String = TextBox1.Text
        Dim myChars() As Char = pass.ToCharArray()
        For Each ch As Char In myChars
            If Char.IsDigit(ch) Then
                nmr += 1
            End If

            If validatePassword(pass) = True Then
                sgn += 1
            End If
        Next

        If nmr = 0 Then
            MsgBox("uw wachtwoord moet een nummer bevatten")

        End If
        If sgn = 0 Then
            MsgBox("uw wachtwoord moet een speciaal teken bevatten zoals: [~`!@#$%^&*()-_=+';:,./<>?]")

        End If
        If validatePasswordAmount(pass) = False Then
            MsgBox("uw wachtwoord moet minstens 8 tekens bevatten")
        End If

        'gebruikersnaam
        Dim nmr_g As Integer = 0
        Dim sgn_g As Integer = 0
        Dim spatie_g As Integer = 0

        Dim gebruikersnaam As String = TextBox2.Text
        Dim myChars_g() As Char = gebruikersnaam.ToCharArray()
        For Each y As Char In myChars_g
            If Char.IsDigit(y) Then
                nmr_g += 1
            End If

            If validatePassword(gebruikersnaam) = True Then
                sgn_g += 1
            End If

            If validateGebruikersnaam(gebruikersnaam) = True Then
                spatie_g += 1
            End If
        Next

        If nmr_g > 0 Then
            MsgBox("uw gebruikersnaam mag geen nummer bevatten bevatten")

        End If
        If sgn_g > 0 Then
            MsgBox("uw gebruikersnaam mag geen speciaal teken bevatten zoals: [~`!@#$%^&*()-_=+';:,./<>?]")

        End If

        If spatie_g = 0 Then
            MsgBox("uw gebruikersnaam moet uit uw naam en voornaam bestaan, met een spatie tussen")

        End If
        Dim checker_timer As Integer = 5000 + ((check + 1) / 3) * 5000

        If nmr > 0 And nmr_g = 0 And sgn > 0 And sgn_g = 0 And spatie_g > 0 And validatePasswordAmount(pass) = True Then
            MsgBox("succesvol ingelogd")

        Else
            check += 1
        End If

        If nmr > 0 And nmr_g = 0 And sgn > 0 And sgn_g = 0 And spatie_g > 0 And validatePasswordAmount(pass) = True Then
            check = 0
        Else

            If check = 3 Then
                MsgBox("verkeerd passwoord te vaak ingegeven, u gaat 10 seconden moeten wachten")
                Threading.Thread.Sleep(10000)
            ElseIf check Mod 3 = 0 Then

                MsgBox("verkeerd passwoord te vaak ingegeven, u gaat " & checker_timer / 1000 & " seconden moeten wacthen")
                Threading.Thread.Sleep(checker_timer)
            Else
            End If


        End If


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.PasswordChar = "*" Then
            TextBox1.PasswordChar = ""
        Else
            TextBox1.PasswordChar = "*"
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub
End Class
