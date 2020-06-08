import Vue from 'vue'
import Vuex from 'vuex'
import * as Mutations from './mutation-types.js'

Vue.use(Vuex)

export default new Vuex.Store({
    state:{
        count:1,
        todos:[
            {id:1,name:"张三"},
            {id:2,name:"李四"},
        ]
    },
    mutations:{
        increment(state){
            state.count++;
        },
        incrementObj(state,obj){
            state.count+=obj.count;
        },
        [Mutations.SOME_MUTATION](state){
            state.count+=2;
        }
    },
    getters:{
        nameTodos:state=>{
            return state.todos.filter(v=>v.id<=1);
        },
        getTodoById:(state)=>(id)=>{
            return state.todos.filter(v=>v.id==id);
        }
    },
    actions:{
        incrementObj(context,obj){
            return new Promise((resolve,reject)=>{
                setTimeout(() => {
                    context.commit('incrementObj',obj);
                    resolve();
                }, 1000);
            })
        },
        // async increment12(context,obj){
        //     //await context.dispatch('incrementObj',obj);
        //     //context.commit('increment');
        // },
    },
})