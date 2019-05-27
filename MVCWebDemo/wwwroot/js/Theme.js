$(function () {
        $("<audio></audio>").attr({
            'src': 'music/jungle.mp3',
            'volume': 0.4,
            'autoplay': 'autoplay'
    }).appendTo("body");
    console.log('x');
})