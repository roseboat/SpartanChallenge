$(function() {

    $('#unit-form-link').click(function(e) {
        $("#unit-form").delay(100).fadeIn(100);
        $("#item-form").fadeOut(100);
        $('#item-form-link').removeClass('active');
        $(this).addClass('active');
        e.preventDefault();
    });
    $('#item-form-link').click(function(e) {
        $("#item-form").delay(100).fadeIn(100);
        $("#unit-form").fadeOut(100);
        $('#unit-form-link').removeClass('active');
        $(this).addClass('active');
        e.preventDefault();
    });

});

  $(document).ready(function() {
        $.get("api/values/", function(Data) {
            $.each(Data, function(index, equip){

                 $(".items").append('<li class="list-group-item list-group-item-dark"><p>' + equip.serializedExternalID + '</p><p>'+ equip.equipmentExternalID+'</p><p>'+ equip.equipmentDescription + '</p></li>');
              });
          });
      });

   $(document).ready(function() {
     $('#search-unit').click(function() {
       $(".items").empty();
       var unitNoInput = ($('#unit-input').val());

       if (!invalid(unitNoInput)) {
         $.get("api/values/unit/"+ unitNoInput,
           function(Data) {
             $.each(Data, function(index, equip) {
               $(".items").append('<li class="list-group-item list-group-item-dark"><p id="serialID">' + equip.serializedExternalID + '</p><p>' + equip.equipmentExternalID + '</p><p>' + equip.equipmentDescription + '</p></li>');
             });
           });
       } else {
         alert("Invalid input");
       }
     });
   });

   $(document).ready(function() {
     $('#search-item').click(function() {
       $(".items").empty();
       var itemNoInput = ($('#item-input').val());

       if (!invalid(itemNoInput)) {
         $.get("api/values/item/"+ itemNoInput,
           function(Data) {
             $.each(Data, function(index, equip) {
               $(".items").append('<li class="list-group-item list-group-item-dark"><p>' + equip.serializedExternalID + '</p><p>' + equip.equipmentExternalID + '</p><p>' + equip.equipmentDescription + '</p></li>');
             });

           });
       } else {
         alert("Invalid input");
       }
     });
   });

function invalid(input) {
  switch (input) {
    case "":
    case 0:
    case "0":
    case null:
    case false:
    case typeof this == "undefined":
      return true;
    default:
      return false;
  }
}