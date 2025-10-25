<template>
  <div class="vessel-detail">
    <!-- Loading State -->
    <div v-if="isLoading" class="loading">
      <div class="spinner"></div>
      <p>Loading vessel details...</p>
    </div>

    <!-- Error State -->
    <div v-else-if="hasError" class="error">
      <p>{{ error }}</p>
      <button @click="fetchVessel" class="btn btn-primary">Retry</button>
    </div>

    <!-- Vessel Details -->
    <div v-else-if="currentVessel" class="vessel-content">
      <div class="header">
        <div class="header-info">
          <h1>{{ currentVessel.name }}</h1>
          <p class="imo">IMO: {{ currentVessel.imo }}</p>
          <span :class="['status-badge', `status-${currentVessel.status.toLowerCase()}`]">
            {{ currentVessel.status }}
          </span>
        </div>
        <div class="header-actions">
          <router-link :to="`/vessels/${currentVessel.id}/edit`" class="btn btn-warning">
            Edit Vessel
          </router-link>
          <router-link to="/vessels" class="btn btn-outline">
            Back to List
          </router-link>
        </div>
      </div>

      <div class="vessel-grid">
        <!-- Basic Information -->
        <div class="info-card">
          <h3>Basic Information</h3>
          <div class="info-grid">
            <div class="info-item">
              <label>Vessel Type:</label>
              <span>{{ currentVessel.vesselType }}</span>
            </div>
            <div class="info-item">
              <label>Flag:</label>
              <span>{{ currentVessel.flag }}</span>
            </div>
            <div class="info-item">
              <label>Year Built:</label>
              <span>{{ currentVessel.yearBuilt || 'N/A' }}</span>
            </div>
            <div class="info-item">
              <label>Owner:</label>
              <span>{{ currentVessel.owner || 'N/A' }}</span>
            </div>
            <div class="info-item">
              <label>Call Sign:</label>
              <span>{{ currentVessel.callSign || 'N/A' }}</span>
            </div>
            <div class="info-item">
              <label>MMSI:</label>
              <span>{{ currentVessel.mmsi || 'N/A' }}</span>
            </div>
          </div>
        </div>

        <!-- Technical Specifications -->
        <div class="info-card">
          <h3>Technical Specifications</h3>
          <div class="info-grid">
            <div class="info-item">
              <label>Gross Tonnage:</label>
              <span>{{ currentVessel.grossTonnage ? `${currentVessel.grossTonnage.toLocaleString()} GT` : 'N/A' }}</span>
            </div>
            <div class="info-item">
              <label>Deadweight Tonnage:</label>
              <span>{{ currentVessel.deadweightTonnage ? `${currentVessel.deadweightTonnage.toLocaleString()} DWT` : 'N/A' }}</span>
            </div>
            <div class="info-item">
              <label>Length Overall:</label>
              <span>{{ currentVessel.lengthOverall ? `${currentVessel.lengthOverall}m` : 'N/A' }}</span>
            </div>
            <div class="info-item">
              <label>Beam:</label>
              <span>{{ currentVessel.beam ? `${currentVessel.beam}m` : 'N/A' }}</span>
            </div>
            <div class="info-item">
              <label>Draft:</label>
              <span>{{ currentVessel.draft ? `${currentVessel.draft}m` : 'N/A' }}</span>
            </div>
            <div class="info-item">
              <label>Max Crew:</label>
              <span>{{ currentVessel.maxCrew || 'N/A' }}</span>
            </div>
          </div>
        </div>

        <!-- Performance -->
        <div class="info-card">
          <h3>Performance</h3>
          <div class="info-grid">
            <div class="info-item">
              <label>Engine Power:</label>
              <span>{{ currentVessel.enginePowerKW ? `${currentVessel.enginePowerKW} kW` : 'N/A' }}</span>
            </div>
            <div class="info-item">
              <label>Max Speed:</label>
              <span>{{ currentVessel.maxSpeedKnots ? `${currentVessel.maxSpeedKnots} knots` : 'N/A' }}</span>
            </div>
          </div>
        </div>

        <!-- Notes -->
        <div v-if="currentVessel.notes" class="info-card full-width">
          <h3>Notes</h3>
          <p class="notes">{{ currentVessel.notes }}</p>
        </div>

        <!-- Audit Information -->
        <div class="info-card full-width">
          <h3>Audit Information</h3>
          <div class="info-grid">
            <div class="info-item">
              <label>Created At:</label>
              <span>{{ formatDate(currentVessel.createdAt) }}</span>
            </div>
            <div class="info-item">
              <label>Created By:</label>
              <span>{{ currentVessel.createdBy || 'N/A' }}</span>
            </div>
            <div v-if="currentVessel.updatedAt" class="info-item">
              <label>Updated At:</label>
              <span>{{ formatDate(currentVessel.updatedAt) }}</span>
            </div>
            <div v-if="currentVessel.updatedBy" class="info-item">
              <label>Updated By:</label>
              <span>{{ currentVessel.updatedBy }}</span>
            </div>
          </div>
        </div>
      </div>
    </div>

    <!-- Not Found -->
    <div v-else class="not-found">
      <h2>Vessel Not Found</h2>
      <p>The vessel you're looking for doesn't exist.</p>
      <router-link to="/vessels" class="btn btn-primary">Back to Vessels</router-link>
    </div>
  </div>
</template>

<script setup lang="ts">
import { computed, onMounted } from 'vue'
import { useRoute } from 'vue-router'
import { useVesselStore } from '@/stores/vesselStore'

const route = useRoute()
const vesselStore = useVesselStore()

// Computed properties
const currentVessel = computed(() => vesselStore.currentVessel)
const isLoading = computed(() => vesselStore.isLoading)
const hasError = computed(() => vesselStore.hasError)
const error = computed(() => vesselStore.error)

// Methods
const fetchVessel = async () => {
  const vesselId = parseInt(route.params.id as string)
  if (vesselId) {
    await vesselStore.fetchVesselById(vesselId)
  }
}

const formatDate = (dateString: string) => {
  return new Date(dateString).toLocaleDateString('en-US', {
    year: 'numeric',
    month: 'long',
    day: 'numeric',
    hour: '2-digit',
    minute: '2-digit'
  })
}

// Lifecycle
onMounted(() => {
  fetchVessel()
})
</script>

<style scoped>
.vessel-detail {
  max-width: 1200px;
  margin: 0 auto;
  padding: 2rem;
}

.loading, .error, .not-found {
  text-align: center;
  padding: 3rem;
  background: white;
  border-radius: 8px;
  box-shadow: 0 2px 4px rgba(0,0,0,0.1);
}

.spinner {
  width: 40px;
  height: 40px;
  border: 4px solid #f3f3f3;
  border-top: 4px solid #3498db;
  border-radius: 50%;
  animation: spin 1s linear infinite;
  margin: 0 auto 1rem;
}

@keyframes spin {
  0% { transform: rotate(0deg); }
  100% { transform: rotate(360deg); }
}

.header {
  display: flex;
  justify-content: space-between;
  align-items: flex-start;
  margin-bottom: 2rem;
  padding: 2rem;
  background: white;
  border-radius: 8px;
  box-shadow: 0 2px 4px rgba(0,0,0,0.1);
}

.header-info h1 {
  color: #2c3e50;
  margin: 0 0 0.5rem 0;
  font-size: 2rem;
}

.imo {
  color: #666;
  font-size: 1.1rem;
  margin: 0 0 1rem 0;
}

.status-badge {
  padding: 0.5rem 1rem;
  border-radius: 20px;
  font-size: 0.875rem;
  font-weight: 500;
  text-transform: uppercase;
}

.status-active {
  background-color: #d4edda;
  color: #155724;
}

.status-inactive {
  background-color: #f8d7da;
  color: #721c24;
}

.status-maintenance {
  background-color: #fff3cd;
  color: #856404;
}

.header-actions {
  display: flex;
  gap: 1rem;
}

.vessel-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
  gap: 2rem;
}

.info-card {
  background: white;
  padding: 1.5rem;
  border-radius: 8px;
  box-shadow: 0 2px 4px rgba(0,0,0,0.1);
}

.info-card.full-width {
  grid-column: 1 / -1;
}

.info-card h3 {
  color: #2c3e50;
  margin: 0 0 1rem 0;
  font-size: 1.25rem;
  border-bottom: 2px solid #3498db;
  padding-bottom: 0.5rem;
}

.info-grid {
  display: grid;
  gap: 0.75rem;
}

.info-item {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 0.5rem 0;
  border-bottom: 1px solid #f0f0f0;
}

.info-item:last-child {
  border-bottom: none;
}

.info-item label {
  font-weight: 600;
  color: #555;
  min-width: 120px;
}

.info-item span {
  color: #2c3e50;
  text-align: right;
}

.notes {
  color: #666;
  line-height: 1.6;
  margin: 0;
  padding: 1rem;
  background-color: #f8f9fa;
  border-radius: 4px;
  border-left: 4px solid #3498db;
}

.btn {
  padding: 0.75rem 1.5rem;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  text-decoration: none;
  display: inline-block;
  font-weight: 500;
  transition: all 0.3s ease;
}

.btn-primary {
  background-color: #3498db;
  color: white;
}

.btn-warning {
  background-color: #ffc107;
  color: #212529;
}

.btn-outline {
  background-color: transparent;
  color: #3498db;
  border: 1px solid #3498db;
}

.btn:hover {
  transform: translateY(-2px);
  box-shadow: 0 4px 8px rgba(0,0,0,0.1);
}
</style>
