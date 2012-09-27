function newImage(arg) {
    if (document.images) {
        rslt = new Image();
        rslt.src = arg;
        return rslt;
    }
}

function changeImages() {
    if (document.images && (preloadFlag == true)) {
        for (var i = 0; i < changeImages.arguments.length; i += 2) {
            document[changeImages.arguments[i]].src = changeImages.arguments[i + 1];
        }
    }
}

function preload(arrayOfImages) {
    $(arrayOfImages).each(function () {
        $('<img />').attr('src', this).attr('id', parseId(this)).attr('atl', parseId(this)).appendTo('body').hide();
    });
}

function parseId(item)
{
    var coolVarParts = item.split('/');
    var id = coolVarParts[coolVarParts.length - 1].split('.');
    return id[0];
}

var arrayOfImages = new Array("images/divider_horizontal.png", "images/divider_vertical.png", "images/SlideShow/fog_london.png", "images/SlideShow/love.png",
                                "images/SlideShow/love_never_fails.png", "images/SlideShow/old_clock.png", "images/SlideShow/old_water_canal.png", "images/SlideShow/walking_the_dog.png",
                                "images/SlideShow/water_fall.png", "images/SlideShow/fog_london_thumb.png", "images/SlideShow/love_thumb.png", "images/SlideShow/love_never_fails_thumb.png",
                                "images/SlideShow/old_clock_thumb.png", "images/SlideShow/old_water_canal_thumb.png", "images/SlideShow/walking_the_dog_thumb.png",
                                "images/SlideShow/water_fall_thumb.png");
                                
var preloadFlag = false;
function preloadImages() {
    if (document.images) {
        divider_horizontal = newImage("images/divider_horizontal.png");
        divider_vertical = newImage("images/divider_vertical.png");
        slideshow_1 = newImage("images/SlideShow/fog_london.png");
        slideshow_2 = newImage("images/SlideShow/love.png");
        slideshow_3 = newImage("images/SlideShow/love_never_fails.png");
        slideshow_4 = newImage("images/SlideShow/old_clock.png");
        slideshow_5 = newImage("images/SlideShow/old_water_canal.png");
        slideshow_6 = newImage("images/SlideShow/walking_the_dog.png");
        slideshow_7 = newImage("images/SlideShow/water_fall.png");

        slideshow_1_thumb = newImage("images/SlideShow/fog_london_thumb.png");
        slideshow_2_thumb = newImage("images/SlideShow/love_thumb.png");
        slideshow_3_thumb = newImage("images/SlideShow/love_never_fails_thumb.png");
        slideshow_4_thumb = newImage("images/SlideShow/old_clock_thumb.png");
        slideshow_5_thumb = newImage("images/SlideShow/old_water_canal_thumb.png");
        slideshow_6_thumb = newImage("images/SlideShow/walking_the_dog_thumb.png");
        slideshow_7_thumb = newImage("images/SlideShow/water_fall_thumb.png");

        preloadFlag = true;
    }
}
