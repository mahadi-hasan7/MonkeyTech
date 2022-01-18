const about = document.querySelector(".about");
const btns = document.querySelectorAll(".tab-btn");
const articles = document.querySelectorAll(".content");
about.addEventListener("click", function (e) {
    const id = e.target.dataset.id;
    if (id) {
        // remove selected from other buttons
        btns.forEach(function (btn) {
            btn.classList.remove("active");
        });
        e.target.classList.add("active");
        // hide other articles
        articles.forEach(function (article) {
            article.classList.remove("active");
        });
        const element = document.getElementById(id);
        element.classList.add("active");
    }
});






// increment decrement

const plus = document.querySelector(".plus"),
    minus = document.querySelector(".minus"),
    num = document.querySelector(".num"),
    error = document.querySelector(".error");

const shakil = document.getElementById("<%= NewName.ClientID %>");


const numberItem = document.querySelector(".itemCount");
console.log(numberItem);
let a = num.nodeValue;

//Response.Write("a : " + a);

console.log("a : " + a);

plus.addEventListener("click", () => {
    a++;
    shakil.nodeValue = a;
    //if (a > 0) {
    //    error.style.visibility = 'hidden';
    //}
});

minus.addEventListener("click", () => {

    if (a > 0) {
        a--;
        shakil.nodeValue = a;
        //num.innerHTML = a;
    }
    else {

        //error.innerHTML = "You can't have negative number of products";
    }
});
//console.log(numberItem);