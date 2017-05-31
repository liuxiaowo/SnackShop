/*中间轮播图*/
var i = 0;
var stop;
/*	每隔2秒运行一次轮播*/
stop = setInterval(function () {
    i++;
    if (i > 4) {
        i = 1;
    }
    xiaoguo2(i);
    xiaoguo(i);
}, 4000)
/*	动作函数*/
function xiaoguo2(n) {
    /*		块一*/
    $('.fugai1')
	.css({ "background-image": "url(./images/lunbo" + n + ".jpg)", 'background-repeat': 'no-repeat', 'display': 'block', "backgroundPosition-x": 0 + 'px' })
	.animate({ "backgroundPosition-x": -500 + 'px' }, 3000)
	.css({ 'display': 'none' })
    //块二
    $('.fugai2')
	.css({ "background-image": "url(./images/lunbo" + n + ".jpg)", 'background-repeat': 'no-repeat', 'display': 'block', "backgroundPosition-x": -500 + 'px' })
	.animate({ "backgroundPosition-x": -500 * 2 + 'px' }, 3000)
	.animate({ 'display': 'none' })
    //块三
    $('.fugai3')
	.css({ "background-image": "url(./images/lunbo" + n + ".jpg)", 'background-repeat': 'no-repeat', 'display': 'block', "backgroundPosition-x": 0 + 'px' })
	.animate({ "backgroundPosition-x": -500 * 3 + 'px' }, 3000)
	.animate({ 'display': 'none' })
    /*		$('.fugai')
        .css({"background-image":"url(image/lunbo"+n+".jpg)",'background-repeat':'no-repeat','display':'block',"backgroundPosition-x":0+'px'})
        .deplay(3000).animate({"backgroundPosition-x":-730*3+'px'},3000)
        .animate({'display':'none'},10)		*/
}
$('.list-li>li').eq(0).css({ 'background-color': 'orange' })
function xiaoguo(n) {
    var b = n - 1;
    $('.list-li>li').css({ 'background-color': '#F9263E' })
    $('.list-li>li').eq(b).css({ 'background-color': 'orange' })
    $('.dian').animate({ 'width': 500 + 'px' }, 2000)
    $('.dian').animate({ 'width': 0 + 'px' }, 100)
    $('.box').animate({ 'margin-left': -n * 500 + 'px' }, 2000, function () {
        if (n == 4) {
            $('.box').css({ 'margin-left': 0 + 'px' })
        }
    })
}
/*	左右按钮*/
function huan(n) {
    var j = i;
    i = i + n;

    if (i > 6) {
        i = 1;
    }
    if (i < 0) {
        i = 5;
    }
    xiaoguo(i);
}
//左箭头
$('.btn-l').click(function () {
    clearInterval(stop);
    stop = null;
    huan(-1);
    if (i == 0) {
        $('.btn-con-l').html('<img src="./images/lunbo' + parseInt(6) + '.jpg">')
    } else {
        $('.btn-con-l').html('<img src="./images/lunbo' + parseInt(i) + '.jpg">')
    }
    $('.box').stop(true, true);
    $('.dian').stop(true, true);

});
//右箭头
$('.btn-r').click(function () {
    clearInterval(stop);
    stop = null;
    huan(1);
    if (i == 5) {
        $('.btn-con-r').html('<img src="./images/lunbo' + parseInt(1) + '.jpg">')
    } else if (i == 6) {
        $('.btn-con-r').html('<img src="./images/lunbo' + parseInt(2) + '.jpg">')
    } else {
        $('.btn-con-r').html('<img src="./images/lunbo' + parseInt(i + 2) + '.jpg">')
    }
    $('.box').stop(true, true);
    $('.dian').stop(true, true);
});
//$('.btn-l').click(function(){huan(-1);});
//$('.btn-r').click(function(){huan(1);});

/*	鼠标放上大块*/
$('.lunbo').mouseover(function () {
    clearInterval(stop);
    stop = null;
    $('.btn').show();

})
/*	鼠标离开大块*/
$('.lunbo').mouseout(function () {
    if (stop == null) {
        stop = setInterval(function () {
            i++;
            if (i > 6) {
                i = 1;
            }
            xiaoguo(i);
            xiaoguo2(i);
        }, 4000)
    }
    $('.btn').hide();
    $('.btn-con-l').text('');
    $('.btn-con-r').text('');
})
/*按钮小标题*/
$('.list-li>li').mouseover(function () {
    clearInterval(stop);
    stop = null;
    i = Number($(this).text());
    xiaoguo($(this).text())
    $('.box').stop(true, true);
    $('.dian').stop(true, true);
})




/*左侧导航栏*/
; (function (a) {
    a.fn.hoverDelay = function (c, f, g, b) {
        var g = g || 200,
        b = b || 200,
        f = f || c;
        var e = [],
        d = [];
        return this.each(function (h) {
            a(this).mouseenter(function () {
                var i = this;
                clearTimeout(d[h]);
                e[h] = setTimeout(function () {
                    c.apply(i)
                },
                g)
            }).mouseleave(function () {
                var i = this;
                clearTimeout(e[h]);
                d[h] = setTimeout(function () {
                    f.apply(i)
                },
                b)
            })
        })
    }
})(jQuery);
$(function () {
    $(".sidebar").hoverDelay(function () {
        $("#sidebar_box").show();
        $(".sidebar_top s").addClass("s_down");
    },
        function () {
            $("#sidebar_box").hide();
            $(".sidebar_top s").removeClass("s_down");
        });
    $(".sidebar_item dd").hoverDelay(function () {
        $(this).find("h3").addClass("sidebar_focus");
        $(this).find(".sidebar_popup").show(0);
    },
    function () {
        $(this).find("h3").removeClass("sidebar_focus");
        $(this).find(".sidebar_popup").hide(0);
    });
});