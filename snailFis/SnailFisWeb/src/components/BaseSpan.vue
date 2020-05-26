<template>
  <div>
        <!-- <span v-bind="$attrs">这是段文字</span>
        {{$attrs["title"]}} -->
        <!-- <input v-bind="$attrs['placeholder']"> -->
        <!-- <button @click="changeFun">change</button> -->
        <input v-on="$listeners">
  </div>
</template>

<script>
export default {
    props:["testStr"],
    inheritAttrs: false,
    data(){
        return{
            str1:"",
        }
    },
    watch:{
        str1:function(newVal){
            this.$emit('update:test-str',newVal)
        }
    },
    methods:{
        changeFun(){
            this.$emit('my-event');
        }
    },
     computed: {
    inputListeners: function () {
      var vm = this
      // `Object.assign` 将所有的对象合并为一个新对象
      return Object.assign({},this.$listeners,{
          // 这里确保组件配合 `v-model` 的工作
          input: function (event) {
            vm.$emit('input', event.target.value)
          }
        }
      )
    }
  },
}
</script>
