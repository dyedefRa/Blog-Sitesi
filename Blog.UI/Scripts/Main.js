//function showPassword() {

//    if ($("#eskiParola").type == "password") {
//        $("#eskiParola").type = "text";

//    } else {
//        $("#eskiParola").type = "password";
//    }
//}
//MAKALE/DETAILS TE BUNLAR

//$('#yorumYap').click(function () {
//    var mesaj = $('#yorum').val();
//    var makaleID =@Model.Id;
//    var yorumYapanID =@aktifKullanici.Id;
//    $.ajax({
//        type: 'POST',
//        url: '/Makale/AjaxYorum/',
//        dataType: 'json',
//        data: { yorumYapanID: yorumYapanID, makaleID: makaleID, yorum: mesaj },
//        success: function (data) {
//            if (data) {
//                alert(data.Mesaj);
//                window.location.reload();

//            } else {
//                alert(data.Mesaj);
//            }
//        },
//        error: function () {
//            alert("WTF");
//        }
//    })
//})


//$(".yorumSil").click(function () {
//    var sonuc = confirm("Bu yorumunuzu silmek istediğinize emin misiniz ?");
//    if (sonuc) {
//        var yorumID = $(this).data("mer");
//        $.ajax({
//            type: 'POST',
//            url: '/Makale/AjaxYorumSil/',
//            data: { id: yorumID },
//            success: function (data) {

//                alert(data.Mesaj);
//                window.location.reload();

//            }

//        })
//    }

//})


/////////////////////////////
//MAKALE/INDEX
//$(document).ready(function () {
//$("#go").click(function () {
//    var makale = $('#arama').val();
//    alert(makale);
//});
//})
