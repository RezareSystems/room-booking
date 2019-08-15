<template>
<div>
    <!-- Trigger the modal with a button -->
    <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Calendar Picker</button>

    <!-- Modal -->
    <div id="myModal" class="modal fade" role="dialog">
    <div class="modal-dialog modal-dialog-centered modal-lg">

        <!-- Modal content-->
        <div class="modal-content">

        <div class="modal-body">
            <v-calendar is-expanded/>
        </div>
        </div>

    </div>
    </div>
</div>

</template>
<script>
// Register component(s)



export default {
    name: 'DatePickerModal',
    props: {
    },
    methods:{
        
        
    },
    data () {
    },
    mounted () {
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
img {
  height: 5em;
}
h3 {
  margin: 40px 0 0;
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

.btn-info, .btn-info:hover, .btn-info:active, .btn-info:focus {
    background-color: rgba(0, 86, 164, 1);
    color: white;
    border-color: rgba(0, 86, 164, 1);
    margin-top: 40px;
}
</style>
