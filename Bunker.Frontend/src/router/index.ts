import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import VesselListView from '../views/VesselListView.vue'
import VesselDetailView from '../views/VesselDetailView.vue'
import VesselCreateView from '../views/VesselCreateView.vue'
import VesselEditView from '../views/VesselEditView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/vessels',
      name: 'vessels',
      component: VesselListView
    },
    {
      path: '/vessels/create',
      name: 'vessel-create',
      component: VesselCreateView
    },
    {
      path: '/vessels/:id',
      name: 'vessel-detail',
      component: VesselDetailView,
      props: true
    },
    {
      path: '/vessels/:id/edit',
      name: 'vessel-edit',
      component: VesselEditView,
      props: true
    }
  ]
})

export default router
