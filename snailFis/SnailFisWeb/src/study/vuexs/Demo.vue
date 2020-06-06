<template>
    <div>
        <span>store中的count值：{{$store.state.count}}</span><br>
        <span>store中的count值：{{count}} </span><br>
        <span>store中的count值：{{countAlias}} </span><br>
        <span>store中的count+2值：{{countAdd2}} </span><br>
        <span>其他computed值：{{num1}} </span><br>
        <span>其他computed值：{{num2}} </span><br>
        <button @click="addCount">add</button>
    </div>
</template>

<script>

import { mapState } from 'vuex'

export default {
    data(){
        return{
            num1:1
        }
    },
    methods:{
        addCount(){
            var self =this;
            self.$store.commit('increment');
            console.log(self.$store.state.count);
        }
    },
    computed:mapState({
        count:(state)=>state.count,
        countAlias:'count',
        countAdd2(state){
            return state.count+2;
        },
        num2(){
            return this.num1+1;
        }
    }),
}
</script>
