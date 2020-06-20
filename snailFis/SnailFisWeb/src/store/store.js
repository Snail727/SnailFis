import Vue from "vue";
import Vuex from "vuex";
import * as Mutations from '@/store/mutation-types.js'
Vue.use(Vuex);
var store = new Vuex.Store({
    // state:{
    //     count:1,
    //     todos:[
    //         {id:1,name:"张三"},
    //         {id:2,name:"李四"},
    //         {id:3,name:"王二麻子"},
    //     ]
    // },
    // mutations:{
    //     increment(state){
    //         state.count++;
    //     },
    //     incrementObj(state,obj){
    //         state.count+=obj.count;
    //     },
    //     [Mutations.SOME_MUTATION](state){
    //         state.count+=2;
    //     }
    // },
    // getters:{
    //     nameTodos:state=>{
    //         return state.todos.filter(v=>v.id<=1);
    //     },
    //     getTodoById:(state)=>(id)=>{
    //         return state.todos.filter(v=>v.id==id);
    //     },
    //     maxNameTodos:state=>{
    //         return state.todos.filter(v=>v.id>2);
    //     },
    // },
    // actions:{
    //     incrementObj(context,obj){
    //         return new Promise((resolve, reject)=>{
    //             setTimeout(() => {
    //                 context.commit('incrementObj',obj);
    //                 resolve('success');
    //             }, 1000);
    //         })
    //     },
    //     increment12(context,obj){
    //         context.dispatch('incrementObj',obj).then(()=>{
    //             context.commit('increment');
    //         });
    //     },
    // },
});

// import Test from "@/store/modules/Test.js";
// store.registerModule("Test", Test);

import TokenInfo from "@/store/modules/TokenInfo.js";
store.registerModule("TokenInfo", TokenInfo);

export default store;