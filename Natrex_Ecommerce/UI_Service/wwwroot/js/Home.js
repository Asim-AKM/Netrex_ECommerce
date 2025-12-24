window.addEventListener("scroll", () => {
    const nav = document.querySelector("nav");
    nav.classList.toggle("scrolled", window.scrollY > 10);
});

let categBtn = document.querySelector(".Category-btn")
let categoryList = document.querySelector(".Categories-list")


categBtn.addEventListener("mouseover", () => {
    categoryList.classList.add("Categories-list-show")
})

document.addEventListener("click", (e) => {
    // if click is outside category button & dropdown
    if (!categoryList.contains(e.target) && !categBtn.contains(e.target)) {
        categoryList.classList.remove("Categories-list-show");
    }
});

let flag = 0

function slideControler(val) {
    flag += val
    slideHandle(flag)
}

function slideHandle(num) {
    let allSlide = document.querySelectorAll(".slide")

    if (num == allSlide.length) {
        flag = 0
        num = 0
    }

    if (num < 0) {
        flag = allSlide.length - 1
        num = allSlide.length - 1
    }

    for (const sl of allSlide) {
        sl.style.display = "none"
    }
    allSlide[num].style.display = "block"
}

slideHandle(flag)

setInterval(() => {
    flag++;
    slideHandle(flag);
}, 8000);






// Reviews 

let reviews = [
    {
        Image: "assets/clients-images/clients.jpeg",
        description: "Amazing shopping experience! The products were exactly as shown, delivery was super fast, and customer support was very helpful. I’ll definitely shop again.",
        cust_name: "Affan Wajid"
    },
    {
        Image: "",
        description: "Highly recommended! Product quality exceeded my expectations, and the team was very responsive to my questions.",
        cust_name: "Saqib Khan"
    },
    {
        Image: "",
        description: "Fast delivery, original products, and great support. This website has become my go-to place for online shopping.",
        cust_name: "Fayaz Khan"
    },
]

let rightArrow = document.querySelector(".right-arrow")
let leftArrow = document.querySelector(".left-arrow")
let cust_image = document.querySelector(".cust-image")
let user_review = document.querySelector("#user-review")
let user_Name = document.querySelector(".user-name")

let index = 0


function showReviews() {
    let user = reviews[index]
    cust_image.src = user.Image
    user_review.textContent = user.description
    user_Name.innerHTML = user.cust_name
}

rightArrow.addEventListener("click", () => {
    index++
    if (index > reviews.length - 1) {
        index = 0
    }
    showReviews()
})
leftArrow.addEventListener("click", () => {
    index--
    if (index < 0) {
        index = reviews.length - 1
    }
    showReviews()
})
showReviews()



// Cart 


let cartBtn = document.querySelectorAll(".add-cart")
let cartCounter = document.querySelector(".counter")
let counterLabel = document.querySelector(".cart-count")
let count = 0

cartBtn.forEach((btn) => {
    btn.addEventListener("click", () => {
        counterLabel.style.display = "flex"
        if (count >= 0) {
            count++
            cartCounter.innerHTML = count
        }
    })
})
