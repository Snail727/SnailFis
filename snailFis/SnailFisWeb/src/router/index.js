import Vue from 'vue'
import Router from 'vue-router'
import HelloWorld from '@/components/HelloWorld'
import Demo from '@/baseData/Demo'
import Demo1 from '@/baseData/Demo1'
import Demo2 from '@/baseData/Demo2'
import Demo3 from '@/baseData/Demo3'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'HelloWorld',
      component: HelloWorld
    },
    {
      path: '/Demo',
      name: 'Demo',
      component: Demo
    },
    {
      path: '/Demo1',
      name: 'Demo1',
      component: Demo1
    },
    {
      path: '/Demo2',
      name: 'Demo2',
      component: Demo2
    },
    {
      path: '/Demo3',
      name: 'Demo3',
      component: Demo3
    },
  ]
})
