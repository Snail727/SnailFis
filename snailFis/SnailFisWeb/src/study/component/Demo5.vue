<template>
    <button @click="helpMe('sdf')">救我</button>
</template>

<script lang="ts">
import Vue from 'vue'
export default Vue.extend({
  components: {
    // TableCom
  },
  data() {
    return {
      msg:'typescript'
    };
  },
  methods:{
    helpMe(name:string){
        alert(this.changeName(name));
    },
    changeName(name:string):string{return name+"123"},
  }
})
</script>
