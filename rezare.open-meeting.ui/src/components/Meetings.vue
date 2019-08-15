<template>
  <div class="hello">
    <div id="dean">
      {{ info }}
    </div>
    <div class="container">
        <div class="row">
            <div class="col-sm">
            One of three columns
            </div>
            <div class="col-sm">
            One of three columns
            </div>
            <div class="col-sm">
            One of three columns
            </div>
        </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'Meetings',
  props: {
    msg: String
  },
  data () {
      return {
        info: null
      }
    },
  mounted () {
      axios
        .get('https://e5hqivepy9.execute-api.ap-southeast-2.amazonaws.com/dev?RoomId=kakapo&BookingDay=2019-08-27')
        .then(response => {this.info = response})
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
</style>
