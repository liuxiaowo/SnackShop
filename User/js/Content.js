var isSecond = 0;
$(function () {
    $("img.lazy").lazyload({
        load: function () {
            $('#container').BlocksIt({
                numOfCol: 4,
                offsetX: 8,
                offsetY: 8
            });
        }
    });
    $(window).scroll(function () {
        isSecond++;
        if (isSecond == 1) {
            // 当滚动到最底部以上50像素时， 加载新内容
            if ($(document).height() - $(this).scrollTop() - $(this).height() < 50) {
                $('#container').append($("#test").html());
                $('#container').BlocksIt({
                    numOfCol: 4,
                    offsetX: 8,
                    offsetY: 8
                });
                $("img.lazy").lazyload();
            }
        }
    });

    //window resize
    var currentWidth = 1100;
    $(window).resize(function () {
        var winWidth = $(window).width();
        var conWidth;
        if (winWidth < 660) {
            conWidth = 440;
            col = 2
        } else if (winWidth < 880) {
            conWidth = 660;
            col = 3
        } else if (winWidth < 1100) {
            conWidth = 880;
            col = 4;
        } else {
            conWidth = 1100;
            col = 5;
        }

        if (conWidth != currentWidth) {
            currentWidth = conWidth;
            $('#container').width(conWidth);
            $('#container').BlocksIt({
                numOfCol: col,
                offsetX: 8,
                offsetY: 8
            });
        }
    });
});