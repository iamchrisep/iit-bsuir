$(".nav > li").hover(function() {
    var a = $(this).find("ul.sub_level");
    a.toggle();
})

$(".sub_level > li").hover(function() {
    var a = $(this).find("ul.sub_sub_level");
    a.toggle();
})
