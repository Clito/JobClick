Imports Microsoft.VisualBasic

Public Class protocolo

    Function geraCheckDigitRES(ByVal cadeia As String) As String

        Dim mult = (Len(cadeia) Mod 2)
        mult = mult + 1
        Dim total = 0
        Dim pos As Integer
        Dim res As Integer

        For pos = 1 To Len(cadeia)

            res = Mid(cadeia, pos, 1) * mult

            If res > 9 Then
                res = Int(res / 10) + (res Mod 10)
            End If

            total = total + res

            If mult = 2 Then
                mult = 1
            Else
                mult = 2
            End If

        Next

        total = ((10 - (total Mod 10)) Mod 10)

        geraCheckDigitRES = total

    End Function

End Class

