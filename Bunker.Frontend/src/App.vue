<template>
  <div id="app">
    <nav class="navbar">
      <div class="navbar-brand">
        <h1>Bunker Management System</h1>
      </div>
      <div class="navbar-menu">
        <router-link to="/" class="nav-link">Home</router-link>
        <router-link to="/vessels" class="nav-link">Vessels</router-link>
        <router-link to="/ports" class="nav-link">Ports</router-link>
        <router-link to="/voyages" class="nav-link">Voyages</router-link>
        <router-link to="/port-calls" class="nav-link">Port Calls</router-link>
        <router-link to="/bunker-orders" class="nav-link">Bunker Orders</router-link>
      </div>
    </nav>
    <main class="main-content">
      <router-view />
    </main>
  </div>
</template>

<script setup lang="ts">
// Main app component
</script>

<style scoped>
.navbar {
  background-color: #2c3e50;
  color: white;
  padding: 1rem 2rem;
  display: flex;
  justify-content: space-between;
  align-items: center;
  box-shadow: 0 2px 4px rgba(0,0,0,0.1);
}

.navbar-brand h1 {
  margin: 0;
  font-size: 1.5rem;
}

.navbar-menu {
  display: flex;
  gap: 1rem;
}

.nav-link {
  color: white;
  text-decoration: none;
  padding: 0.5rem 1rem;
  border-radius: 4px;
  transition: background-color 0.3s;
}

.nav-link:hover,
.nav-link.router-link-active {
  background-color: #34495e;
}

.main-content {
  padding: 2rem;
  min-height: calc(100vh - 80px);
  background-color: #f8f9fa;
}
</style>
