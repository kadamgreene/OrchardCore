/// <reference types="jquery" />
/// <reference types="bootstrap" />
(function () {
    document.querySelectorAll(".sidebar")
        .forEach(function (sidebar) {
        if (sidebar.innerHTML.trim() == "") {
            sidebar.remove();
        }
    });
    (function ($) {
        $('.dropdown-menu a.dropdown-toggle').on('click', function (e) {
            console.log(this);
            if (!$(this).next().hasClass('show')) {
                $(this).parents('.dropdown-menu').first().find('.show').removeClass("show");
            }
            var $subMenu = $(this).next(".dropdown-menu");
            $subMenu.toggleClass('show');
            $(this).parents('li.nav-item.dropdown.show').on('hidden.bs.dropdown', function (e) {
                //console.log(this);
                $(this).find('ul.dropdown-menu.show').each(function () {
                    $(this).removeClass("show");
                });
            });
            return false;
        });
    })(jQuery);
})();
