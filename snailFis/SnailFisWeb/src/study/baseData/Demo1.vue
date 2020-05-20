<template>
  <div>
    <span v-once>data1:{{data1}}<input v-model="data1"></span><br>
    <p>data2:htmlcode:{{data2}}</p>
    <p>data2:v-html的内容会完全替代被绑定中的标签中的内容<span v-html="data2"></span></p>
    <p :id="data3">data3:no3</p>
    <span>data4:<span v-if="data4">忍者</span><span>{{data4?'yes':'no'}}</span><button @click="data4=!data4">change</button></span><br>
    <div></div>
    <p id='no5'>data5:<button @[eventName]="change">触发事件</button><button @click="changeEvents">改变事件</button></p>
    <hr>
    <span>data6:<input v-model.number="data6" type="number">+<input v-model.number="data7" type="number">={{sumData}}-----{{data8}}</span>
    <todo-item></todo-item>
  </div>
</template>

<script>
export default {
  data(){
    return{
      data1:'Hello Vue!',
      data2:'<span style="color:red;">this is red text</span>',
      data3:'no3',
      data4:true,
      data5:true,
      eventName:'click',
      data6:1,
      data7:2,
      data8:0,
    }
  },
  methods:{
      changeEvents(){
          var self=this;
          self.data5=!self.data5;
          if(self.data5){self.eventName="click";}
          else{self.eventName="mouseover";}
      },
      change()
      {
          alert('233');
          
      }
  },
  computed:{
    sumData(){
      return this.data6+this.data7;
    }
  },
  watch:{
    data6(newVal,oldVal){
      this.data8=oldVal+this.data7;
    },
    data7(newVal,oldVal){
      this.data8=oldVal+this.data6;
    }
  }
}
</script>