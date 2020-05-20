<template>
  <div>
      <div><label>{{firstNum}}</label><button @click="firstNum++">Add</button></div>
      <div><label>{{firstNum}}</label><button @click="firstFun">Add</button></div>
      <div><label>{{firstNum}}</label><button @click.once="alertNum(firstNum)">alert</button></div>
      <div><button @click="warn($event)">alert</button></div>
      <div><input @keyup.enter="change" v-model="firstNum"></div>
      <div><input @keyup.alt.67="change" v-model="firstNum"></div>
      <div><input @click.ctrl="change" v-model="firstNum"></div>
      <div><input @click.exact="change" v-model="firstNum"></div>
      <div><input @click.right="change" v-model="firstNum"></div>
  </div>
</template>

<script>
export default {
  data(){
    return{
        firstNum:0,
    }
  },
  methods:{
      firstFun(){
        this.firstNum++;
      },
      alertNum(num){
          alert(num);
      },
      warn(event){
        if (event) {
            event.preventDefault()
        }
      },
      change(){
          this.firstNum=0;
      }
  }
}
</script>
