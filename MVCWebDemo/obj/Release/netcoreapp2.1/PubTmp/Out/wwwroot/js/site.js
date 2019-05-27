// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

setInterval(function () {
    if (typeof TOTAL_MEMORY !== 'undefined') {
        try {
            var totalMem = TOTAL_MEMORY / 1024.0 / 1024.0;
            var usedMem = (TOTAL_STACK + (STATICTOP - STATIC_BASE) +
                (DYNAMICTOP - DYNAMIC_BASE)) / 1024.0 / 1024.0;
            console.log('Memory stats - used: ' + Math.ceil(usedMem) + 'M' +
                ' free: ' + Math.floor(totalMem - usedMem) + 'M');
        } catch (e) { }
    }
}, 5000);
