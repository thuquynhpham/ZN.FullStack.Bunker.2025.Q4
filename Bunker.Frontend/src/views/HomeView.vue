<template>
  <div class="home">
    <div class="hero-section">
      <h1>Welcome to Bunker Management System</h1>
      <p>Manage your vessels, ports, voyages, and bunker orders efficiently</p>
    </div>
    
    <div class="features-grid">
      <div class="feature-card">
        <h3>Vessel Management</h3>
        <p>Track and manage your fleet of vessels with detailed specifications and status information.</p>
        <router-link to="/vessels" class="btn btn-primary">Manage Vessels</router-link>
      </div>
      
      <div class="feature-card">
        <h3>Port Management</h3>
        <p>Maintain a comprehensive database of ports and their facilities worldwide.</p>
        <router-link to="/ports" class="btn btn-primary">Manage Ports</router-link>
      </div>
      
      <div class="feature-card">
        <h3>Voyage Planning</h3>
        <p>Plan and track vessel voyages with detailed route and schedule information.</p>
        <router-link to="/voyages" class="btn btn-primary">Manage Voyages</router-link>
      </div>
      
      <div class="feature-card">
        <h3>Port Calls</h3>
        <p>Schedule and manage vessel port calls with arrival and departure tracking.</p>
        <router-link to="/port-calls" class="btn btn-primary">Manage Port Calls</router-link>
      </div>
      
      <div class="feature-card">
        <h3>Bunker Orders</h3>
        <p>Process and track bunker fuel orders for your vessels.</p>
        <router-link to="/bunker-orders" class="btn btn-primary">Manage Bunker Orders</router-link>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
// Home view component
</script>

<style scoped>
.home {
  max-width: 1200px;
  margin: 0 auto;
  padding: 2rem;
}

.hero-section {
  text-align: center;
  margin-bottom: 3rem;
  padding: 3rem 0;
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
  color: white;
  border-radius: 12px;
}

.hero-section h1 {
  font-size: 3rem;
  margin-bottom: 1rem;
  font-weight: 700;
}

.hero-section p {
  font-size: 1.2rem;
  opacity: 0.9;
}

.features-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
  gap: 2rem;
  margin-top: 2rem;
}

.feature-card {
  background: white;
  padding: 2rem;
  border-radius: 12px;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
  transition: transform 0.3s ease, box-shadow 0.3s ease;
}

.feature-card:hover {
  transform: translateY(-4px);
  box-shadow: 0 8px 25px rgba(0, 0, 0, 0.15);
}

.feature-card h3 {
  color: #2c3e50;
  margin-bottom: 1rem;
  font-size: 1.5rem;
}

.feature-card p {
  color: #666;
  margin-bottom: 1.5rem;
  line-height: 1.6;
}

.btn {
  display: inline-block;
  padding: 0.75rem 1.5rem;
  border-radius: 6px;
  text-decoration: none;
  font-weight: 500;
  transition: all 0.3s ease;
  border: none;
  cursor: pointer;
}

.btn-primary {
  background-color: #3498db;
  color: white;
}

.btn-primary:hover {
  background-color: #2980b9;
  transform: translateY(-2px);
}
</style>
