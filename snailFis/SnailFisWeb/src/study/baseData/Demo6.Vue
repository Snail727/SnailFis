<template>
  <div>
      <div><input v-model.trim="str1"><span>msg:{{str1}}</span></div>
      <div><textarea v-model="str2"></textarea><span>msg:{{str2}}</span></div>
      <div><input type="checkbox" v-model="bool1"><span>msg:{{bool1}}</span></div>
      <div>
        <input type="checkbox" id="a" value="alert" v-model="arr1">
        <input type="checkbox" id="b" value="bind" v-model="arr1">
        <input type="checkbox" id="c" value="console" v-model="arr1">
        <span>msg:{{arr1}}</span>
      </div>
      <div>
        <input type="radio" id="a" value="alert" v-model="str3">
        <input type="radio" id="b" value="bind" v-model="str3">
        <input type="radio" id="c" value="console" v-model="str3">
        <span>msg:{{str3}}</span>
      </div>
      <div>
          <select v-model="str4">
              <option value="">请选择</option>
              <option>alert</option>
              <option>bind</option>
              <option>console</option>
          </select>
          <span>{{str4}}</span>
      </div>
      <div>
          <select v-model="arr2" multiple>
              <option value="">请选择</option>
              <option v-for="item in arr3" :key="item.value" :value="item.value">{{item.text}}</option>
          </select>
          <span>{{arr2}}</span>
      </div>
      <div><input type="checkbox" true-value="yes" false-value="no" v-model="str5"><span>{{str5}}</span></div>
      <div><input v-model.number="num1"><span>msg:{{num1}}</span></div>
  </div>
</template>

<script>
export default {
  data(){
    return{
        str1:"",
        str2:"",
        bool1:true,
        arr1:[],
        str3:"",
        str4:"",
        arr2:[],
        arr3:[{value:"1",text:"a"},{value:"2",text:"b"},{value:"3",text:"c"}],
        str5:"",
        num1:0,
    }
  },
  methods:{
  }
}
</script>
