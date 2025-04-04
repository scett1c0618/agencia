// Inicialización de AOS (Animate On Scroll)
AOS.init({
	duration: 800,
	easing: 'slide'
});

(function($) {
	"use strict";

	// Detección de dispositivos móviles
	var isMobile = {
	Android: function() {
		return navigator.userAgent.match(/Android/i);
	},
	BlackBerry: function() {
		return navigator.userAgent.match(/BlackBerry/i);
	},
	iOS: function() {
		return navigator.userAgent.match(/iPhone|iPad|iPod/i);
	},
	Opera: function() {
		return navigator.userAgent.match(/Opera Mini/i);
	},
	Windows: function() {
		return navigator.userAgent.match(/IEMobile/i);
	},
	any: function() {
		return (isMobile.Android() || isMobile.BlackBerry() || isMobile.iOS() || isMobile.Opera() || isMobile.Windows());
	}
	};

	// Efectos de parallax con Stellar.js
	$(window).stellar({
	responsive: true,
	parallaxBackgrounds: true,
	parallaxElements: true,
	horizontalScrolling: false,
	hideDistantElements: false,
	scrollProperty: 'scroll'
	});

	// Ajuste de altura completa para elementos
	var fullHeight = function() {
	$('.js-fullheight').css('height', $(window).height());
	$(window).resize(function(){
		$('.js-fullheight').css('height', $(window).height());
	});
	};
	fullHeight();

	// Scrollax (efectos de parallax alternativos)
	$.Scrollax();

	// Menús desplegables con hover
	$('nav .dropdown').hover(function(){
	var $this = $(this);
	$this.addClass('show');
	$this.find('> a').attr('aria-expanded', true);
	$this.find('.dropdown-menu').addClass('show');
	}, function(){
	var $this = $(this);
	$this.removeClass('show');
	$this.find('> a').attr('aria-expanded', false);
	$this.find('.dropdown-menu').removeClass('show');
	});

	// Efectos al hacer scroll
	var scrollWindow = function() {
	$(window).scroll(function(){
		var $w = $(this),
			st = $w.scrollTop(),
			navbar = $('.ftco_navbar'),
			sd = $('.js-scroll-wrap');

		if (st > 150) {
		if (!navbar.hasClass('scrolled')) {
			navbar.addClass('scrolled');  
		}
		} 
		if (st < 150) {
		if (navbar.hasClass('scrolled')) {
			navbar.removeClass('scrolled sleep');
		}
		} 
		if (st > 350) {
		if (!navbar.hasClass('awake')) {
			navbar.addClass('awake');  
		}
		if(sd.length > 0) {
			sd.addClass('sleep');
		}
		}
		if (st < 350) {
		if (navbar.hasClass('awake')) {
			navbar.removeClass('awake');
			navbar.addClass('sleep');
		}
		if(sd.length > 0) {
			sd.removeClass('sleep');
		}
		}
	});
	};
	scrollWindow();

	// Contadores animados
	var counter = function() {
	$('#section-counter, .hero-wrap, .ftco-counter').waypoint(function(direction) {
		if(direction === 'down' && !$(this.element).hasClass('ftco-animated')) {
		var comma_separator_number_step = $.animateNumber.numberStepFactories.separator(',');
		$('.number').each(function(){
			var $this = $(this),
				num = $this.data('number');
			$this.animateNumber(
			{
				number: num,
				numberStep: comma_separator_number_step
			}, 7000
			);
		});
		}
	}, { offset: '95%' });
	};
	counter();

	// Animaciones al aparecer elementos
	var contentWayPoint = function() {
	var i = 0;
	$('.ftco-animate').waypoint(function(direction) {
		if(direction === 'down' && !$(this.element).hasClass('ftco-animated')) {
		i++;
		$(this.element).addClass('item-animate');
		setTimeout(function(){
			$('body .ftco-animate.item-animate').each(function(k){
			var el = $(this);
			setTimeout(function() {
				var effect = el.data('animate-effect');
				if (effect === 'fadeIn') {
				el.addClass('fadeIn ftco-animated');
				} else if (effect === 'fadeInLeft') {
				el.addClass('fadeInLeft ftco-animated');
				} else if (effect === 'fadeInRight') {
				el.addClass('fadeInRight ftco-animated');
				} else {
				el.addClass('fadeInUp ftco-animated');
				}
				el.removeClass('item-animate');
			}, k * 50, 'easeInOutExpo');
			});
		}, 100);
		}
	}, { offset: '95%' });
	};
	contentWayPoint();

	// Navegación suave (smooth scroll)
	var OnePageNav = function() {
	$(".smoothscroll[href^='#'], #ftco-nav ul li a[href^='#']").on('click', function(e) {
		e.preventDefault();
		var hash = this.hash,
			navToggler = $('.navbar-toggler');
		$('html, body').animate({
		scrollTop: $(hash).offset().top
		}, 700, 'easeInOutExpo', function(){
		window.location.hash = hash;
		});
		if (navToggler.is(':visible')) {
		navToggler.click();
		}
	});
	};
	OnePageNav();

})(jQuery);