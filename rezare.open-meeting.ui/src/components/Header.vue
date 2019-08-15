<template>
    <div class="hello">
        <div class="row">
            <div class="col-6">
                <img alt="Vue logo" src="../assets/Rezare-Logo.png">
            </div>
            <div class="col-6">
                <h2>10:00 PM</h2>
                <h4>Thurs, August 15, 2019</h4>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'HelloWorld',
    props: {
        msg: String,
        info: String,
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
img {
    height: 5em;
    float: left;
}
h2 {
    font-size: 2em;
    color: #0057A3;
    padding-right: 0.5em;
    float: right;
}
h3 {
    margin: 40px 0 0;
}
h4 {
    float: right;
    font-size: 1em;
    color: #6D6E71;
    margin-right: 0.5em;
}
ul {
    list-style-type: none;
    padding: 0;
}
li {
    display: inline-block;
    margin: 0 10px;
}
a {
    color: #42b983;
}
</style>
