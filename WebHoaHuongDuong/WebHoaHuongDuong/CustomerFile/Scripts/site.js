
//   $(document).ready(function () {
//       $(document).on("scroll", onScroll);
 
//       $('a[href^="#"]').on('click', function (e) {
//           e.preventDefault();
//           $(document).off("scroll");
 
//           $('a').each(function () {
//               $(this).removeClass('active');
//           })
//           $(this).addClass('active');
 
//           var target = this.hash;
//           $target = $(target);
//           $('html, body').stop().animate({
//               'scrollTop': $target.offset().top
//           }, 500, 'swing', function () {
//               window.location.hash = target;
//               $(document).on("scroll", onScroll);
//           });
//       });
//   });
 
//function onScroll(event){
//    var scrollPosition = $(document).scrollTop();
//    $('nav a').each(function () {
//        var currentLink = $(this);
//        var refElement = $(currentLink.attr("href"));
//        if (refElement.position().top <= scrollPosition && refElement.position().top + refElement.height() > scrollPosition) {
//            $('nav ul li a').removeClass("active");
//            currentLink.addClass("active");
//        }
//        else{
//            currentLink.removeClass("active");
//        }
//    });
//}

//jQuery(function ($) {
//    // custom formatting example
//    $('.timer').data('countToOptions', {
//        formatter: function (value, options) {
//            return value.toFixed(options.decimals).replace(/\B(?=(?:\d{3})+(?!\d))/g, ',');
//        }
//    });
 
//    // start all the timers
//    $('#starts').waypoint(function() {
//        $('.timer').each(count);
//    });
 
//    function count(options) {
//        var $this = $(this);
//        options = $.extend({}, options || {}, $this.data('countToOptions') || {});
//        $this.countTo(options);
//    }
   
//});
$(document).ready(function () {

    $(".element-animation1").click(function () {

        $("#reason1").attr("required", "");
        $("#reason2").hide("slow", function () {
            $("#reason2").removeAttr("required");
        })
        $("#reason3").hide("slow", function () {
            $("#reason3").removeAttr("required");
        })
        $("#reason1").show("slow", function () {
            // Animation complete.
        })

    })
    $(".element-animation3").click(function () {

        $("#reason3").attr("required", "");
        $("#reason2").hide("slow", function () {
            $("#reason2").removeAttr("required");

        })
        $("#reason1").hide("slow", function () {
            $("#reason1").removeAttr("required");
        })
        $("#reason3").show("slow", function () {
            // Animation complete.
        })

    })
    $(".element-animation2").click(function () {
        $('textarea', '#khaosat').removeAttr("required");

        $("#reason2").attr("required", "");
        $("#reason1").hide("slow", function () {
            $("#reason1").removeAttr("required");
        })
        $("#reason3").hide("slow", function () {
            $("#reason3").removeAttr("required");
        })
        $("#reason2").show("slow", function () {
            // Animation complete.
        })

    })
})
