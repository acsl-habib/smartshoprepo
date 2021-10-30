$(document).ready(function() {
    $("#sidebarCollapse").on("click", function() {
      $("#sidebar").addClass("active");
    });
  
    $("#sidebarCollapseX").on("click", function() {
      $("#sidebar").removeClass("active");
    });
  
    $("#sidebarCollapse").on("click", function() {
      if ($("#sidebar").hasClass("active")) {
        $(".overlay").addClass("visible");
        console.log("it's working!");
      }
    });
  
    $("#sidebarCollapseX").on("click", function() {
      $(".overlay").removeClass("visible");
    });
  });
  

  
 // shop carosselos
  $(document).ready(function(){
    $(".shop-carousel").owlCarousel({

      navText:['<sapn><i class="shadow-none fa fa-arrow-left"></i><span>','<sapn><i class="fa fa-arrow-right"></i><span>'],
      loop:true,
  
      margin:10,
      
      dots:false,
      nav:true,
      responsive:{
          0:{
              items:4
          },
          600:{
              items:3
          },
          1000:{
              items:6,
           
          }
      }
  });
  });


  // brand carosselos
  $(document).ready(function(){
    $(".brand-carousel").owlCarousel({

      navText:['<sapn><i class="shadow-none fa fa-arrow-left"></i><span>','<sapn><i class="fa fa-arrow-right"></i><span>'],
      loop:true,
  
      margin:10,
      
      dots:false,
      nav:true,
      responsive:{
          0:{
              items:4
          },
          600:{
              items:3
          },
          1000:{
              items:7,
           
          }
      }
  });
  });


// Home carosselos
$(document).ready(function () {
    $(".home-carousel").owlCarousel({

        navText: ['<sapn><i class="shadow-none fa fa-arrow-left"></i><span>', '<sapn><i class="fa fa-arrow-right"></i><span>'],
        loop: true,

        margin: 10,
        autoplay: true,
        autoplayTimeout: 5000,
        autoplayHoverPause: true,

        dots: false,
        nav: true,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 1
            },
            1000: {
                items: 1,

            }
        }
    });
});



  // menu carosselos
  $(document).ready(function(){
    $(".menu-carousel").owlCarousel({

      navText:['<sapn><i class="shadow-none fa fa-arrow-left"></i><span>','<sapn><i class="fa fa-arrow-right"></i><span>'],
      loop:true,
  
      margin:10,
      
      dots:false,
      nav:true,
      responsive:{
          0:{
              items:4
          },
          600:{
              items:3
          },
          1000:{
              items:6,
           
          }
      }
  });
  });

    // home appliance
    $(document).ready(function(){
        $(".home-appliance-carousel").owlCarousel({
    
          navText:['<sapn><i class="shadow-none fa fa-arrow-left"></i><span>','<sapn><i class="fa fa-arrow-right"></i><span>'],
          loop:true,
      
          margin:10,
          
          dots:false,
          nav:true,
          responsive:{
              0:{
                  items:4
              },
              600:{
                  items:3
              },
              1000:{
                  items:7,
               
              }
          }
      });
    });

      //product carosel

  $(document).ready(function(){
    $(".product-carousel").owlCarousel({

      navText:['<sapn><i class="shadow-none fa fa-arrow-left"></i><span>','<sapn><i class="fa fa-arrow-right"></i><span>'],
      loop:true,
  
      margin:10,
      
      dots:false,
      nav:true,
      responsive:{
          0:{
              items:2
          },
          600:{
              items:3
          },
          1000:{
              items:5,
           
          }
      }
  });
  });

    


  //sticky nav
  $(document).ready(function () {
    // Custom function which toggles between sticky class (is-sticky)
    var stickyToggle = function (sticky, stickyWrapper, scrollElement) {
        var stickyHeight = sticky.outerHeight();
        var stickyTop = stickyWrapper.offset().top;
        if (scrollElement.scrollTop() >= stickyTop) {
            stickyWrapper.height(stickyHeight);
            sticky.addClass("is-sticky");
        }
        else {
            sticky.removeClass("is-sticky");
            stickyWrapper.height('auto');
        }
    };

    // Find all data-toggle="sticky-onscroll" elements
    $('[data-toggle="sticky-onscroll"]').each(function () {
        var sticky = $(this);
        var stickyWrapper = $('<div>').addClass('sticky-wrapper'); // insert hidden element to maintain actual top offset on page
        sticky.before(stickyWrapper);
        sticky.addClass('sticky');

        // Scroll & resize events
        $(window).on('scroll.sticky-onscroll resize.sticky-onscroll', function () {
            stickyToggle(sticky, stickyWrapper, $(this));
        });

        // On page load
        stickyToggle(sticky, stickyWrapper, $(window));
    });
});

// When the user scrolls the page, execute myFunction
  