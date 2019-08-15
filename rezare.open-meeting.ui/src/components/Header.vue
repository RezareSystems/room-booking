<template>
    <div class="container p-0">
        <div class="row">
            <div class="col-6 d-inline-flex justify-content-left">
                <img alt="Vue logo" src="../assets/Rezare-Logo.png">
            </div>
            <div class="col-6">
                <h2 class="w-100 text-right m-0 pt-2">{{ timeNow }}</h2>
                <h4 class="w-100 text-right m-0">{{ dateToday }}</h4>
            </div>
        </div>
    </div>
</template>

<script>

export default {
    name: 'HelloWorld',
    data() {
        return {
            dateToday: new Date().toDateString(),
            timeNow:  new Date().toLocaleString('en-NZ', { hour: 'numeric', minute: 'numeric', hour12: true }).toUpperCase()
        }
    },
    methods:{
        callFunction: function () {
        }
    },
    mounted() {
        this.callFunction();
    }
}
</script>

<style scoped>
img {
    height: 5em;
}
h2 {
    font-size: 2em;
    font-weight: bold;
    color: #0057A3;
    padding-right: 0.5em;
}
h3 {
    margin: 40px 0 0;
}
h4 {
    font-size: 1em;
    color: #6D6E71;
    padding-right: 1em;
}
</style>
