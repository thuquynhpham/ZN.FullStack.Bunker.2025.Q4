<template>
  <div class="vessel-create">
    <div class="header">
      <h1>Create New Vessel</h1>
      <router-link to="/vessels" class="btn btn-outline">Back to Vessels</router-link>
    </div>

    <form @submit.prevent="handleSubmit" class="vessel-form">
      <div class="form-grid">
        <!-- Basic Information -->
        <div class="form-section">
          <h3>Basic Information</h3>
          <div class="form-group">
            <label for="name">Vessel Name *</label>
            <input 
              v-model="form.name" 
              type="text" 
              id="name" 
              required 
              class="form-input"
              :class="{ 'error': errors.name }"
            />
            <span v-if="errors.name" class="error-message">{{ errors.name }}</span>
          </div>

          <div class="form-group">
            <label for="imo">IMO Number *</label>
            <input 
              v-model="form.imo" 
              type="text" 
              id="imo" 
              required 
              maxlength="7"
              class="form-input"
              :class="{ 'error': errors.imo }"
            />
            <span v-if="errors.imo" class="error-message">{{ errors.imo }}</span>
          </div>

          <div class="form-group">
            <label for="vesselType">Vessel Type *</label>
            <select v-model="form.vesselType" id="vesselType" required class="form-select">
              <option value="">Select Type</option>
              <option value="Container Ship">Container Ship</option>
              <option value="Bulk Carrier">Bulk Carrier</option>
              <option value="Tanker">Tanker</option>
              <option value="General Cargo">General Cargo</option>
              <option value="Ro-Ro">Ro-Ro</option>
              <option value="Passenger Ship">Passenger Ship</option>
              <option value="Other">Other</option>
            </select>
            <span v-if="errors.vesselType" class="error-message">{{ errors.vesselType }}</span>
          </div>

          <div class="form-group">
            <label for="flag">Flag State *</label>
            <input 
              v-model="form.flag" 
              type="text" 
              id="flag" 
              required 
              class="form-input"
              :class="{ 'error': errors.flag }"
            />
            <span v-if="errors.flag" class="error-message">{{ errors.flag }}</span>
          </div>

          <div class="form-group">
            <label for="status">Status *</label>
            <select v-model="form.status" id="status" required class="form-select">
              <option value="Active">Active</option>
              <option value="Inactive">Inactive</option>
              <option value="Maintenance">Maintenance</option>
            </select>
            <span v-if="errors.status" class="error-message">{{ errors.status }}</span>
          </div>
        </div>

        <!-- Technical Specifications -->
        <div class="form-section">
          <h3>Technical Specifications</h3>
          <div class="form-group">
            <label for="grossTonnage">Gross Tonnage</label>
            <input 
              v-model.number="form.grossTonnage" 
              type="number" 
              id="grossTonnage" 
              class="form-input"
              step="0.01"
            />
          </div>

          <div class="form-group">
            <label for="deadweightTonnage">Deadweight Tonnage</label>
            <input 
              v-model.number="form.deadweightTonnage" 
              type="number" 
              id="deadweightTonnage" 
              class="form-input"
              step="0.01"
            />
          </div>

          <div class="form-group">
            <label for="lengthOverall">Length Overall (m)</label>
            <input 
              v-model.number="form.lengthOverall" 
              type="number" 
              id="lengthOverall" 
              class="form-input"
              step="0.01"
            />
          </div>

          <div class="form-group">
            <label for="beam">Beam (m)</label>
            <input 
              v-model.number="form.beam" 
              type="number" 
              id="beam" 
              class="form-input"
              step="0.01"
            />
          </div>

          <div class="form-group">
            <label for="draft">Draft (m)</label>
            <input 
              v-model.number="form.draft" 
              type="number" 
              id="draft" 
              class="form-input"
              step="0.01"
            />
          </div>

          <div class="form-group">
            <label for="yearBuilt">Year Built</label>
            <input 
              v-model.number="form.yearBuilt" 
              type="number" 
              id="yearBuilt" 
              class="form-input"
              min="1800"
              :max="new Date().getFullYear()"
            />
          </div>
        </div>

        <!-- Additional Information -->
        <div class="form-section">
          <h3>Additional Information</h3>
          <div class="form-group">
            <label for="owner">Owner</label>
            <input 
              v-model="form.owner" 
              type="text" 
              id="owner" 
              class="form-input"
            />
          </div>

          <div class="form-group">
            <label for="maxCrew">Max Crew</label>
            <input 
              v-model.number="form.maxCrew" 
              type="number" 
              id="maxCrew" 
              class="form-input"
              min="1"
            />
          </div>

          <div class="form-group">
            <label for="enginePowerKW">Engine Power (kW)</label>
            <input 
              v-model.number="form.enginePowerKW" 
              type="number" 
              id="enginePowerKW" 
              class="form-input"
              step="0.01"
            />
          </div>

          <div class="form-group">
            <label for="maxSpeedKnots">Max Speed (knots)</label>
            <input 
              v-model.number="form.maxSpeedKnots" 
              type="number" 
              id="maxSpeedKnots" 
              class="form-input"
              step="0.01"
            />
          </div>

          <div class="form-group">
            <label for="callSign">Call Sign</label>
            <input 
              v-model="form.callSign" 
              type="text" 
              id="callSign" 
              class="form-input"
              maxlength="10"
            />
          </div>

          <div class="form-group">
            <label for="mmsi">MMSI</label>
            <input 
              v-model="form.mmsi" 
              type="text" 
              id="mmsi" 
              class="form-input"
              maxlength="9"
            />
          </div>
        </div>

        <!-- Notes -->
        <div class="form-section full-width">
          <h3>Notes</h3>
          <div class="form-group">
            <label for="notes">Additional Notes</label>
            <textarea 
              v-model="form.notes" 
              id="notes" 
              class="form-textarea"
              rows="4"
            ></textarea>
          </div>
        </div>
      </div>

      <!-- Form Actions -->
      <div class="form-actions">
        <button type="button" @click="resetForm" class="btn btn-outline">Reset</button>
        <button type="submit" :disabled="isLoading" class="btn btn-primary">
          <span v-if="isLoading">Creating...</span>
          <span v-else>Create Vessel</span>
        </button>
      </div>
    </form>

    <!-- Error Display -->
    <div v-if="hasError" class="error-banner">
      <p>{{ error }}</p>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, reactive, computed } from 'vue'
import { useRouter } from 'vue-router'
import { useVesselStore } from '@/stores/vesselStore'
import type { CreateVesselRequest } from '@/types'

const router = useRouter()
const vesselStore = useVesselStore()

// Form data
const form = reactive<CreateVesselRequest>({
  imo: '',
  name: '',
  vesselType: '',
  flag: '',
  grossTonnage: undefined,
  deadweightTonnage: undefined,
  lengthOverall: undefined,
  beam: undefined,
  draft: undefined,
  yearBuilt: undefined,
  owner: '',
  status: 'Active',
  maxCrew: undefined,
  enginePowerKW: undefined,
  maxSpeedKnots: undefined,
  callSign: '',
  mmsi: '',
  createdBy: '',
  notes: ''
})

// Form validation
const errors = ref<Record<string, string>>({})

// Computed properties
const isLoading = computed(() => vesselStore.isLoading)
const hasError = computed(() => vesselStore.hasError)
const error = computed(() => vesselStore.error)

// Methods
const validateForm = () => {
  errors.value = {}

  if (!form.name.trim()) {
    errors.value.name = 'Vessel name is required'
  }

  if (!form.imo.trim()) {
    errors.value.imo = 'IMO number is required'
  } else if (form.imo.length !== 7) {
    errors.value.imo = 'IMO number must be exactly 7 characters'
  }

  if (!form.vesselType) {
    errors.value.vesselType = 'Vessel type is required'
  }

  if (!form.flag.trim()) {
    errors.value.flag = 'Flag state is required'
  }

  if (!form.status) {
    errors.value.status = 'Status is required'
  }

  return Object.keys(errors.value).length === 0
}

const handleSubmit = async () => {
  if (!validateForm()) {
    return
  }

  try {
    await vesselStore.createVessel(form)
    router.push('/vessels')
  } catch (error) {
    console.error('Error creating vessel:', error)
  }
}

const resetForm = () => {
  Object.assign(form, {
    imo: '',
    name: '',
    vesselType: '',
    flag: '',
    grossTonnage: undefined,
    deadweightTonnage: undefined,
    lengthOverall: undefined,
    beam: undefined,
    draft: undefined,
    yearBuilt: undefined,
    owner: '',
    status: 'Active',
    maxCrew: undefined,
    enginePowerKW: undefined,
    maxSpeedKnots: undefined,
    callSign: '',
    mmsi: '',
    createdBy: '',
    notes: ''
  })
  errors.value = {}
}
</script>

<style scoped>
.vessel-create {
  max-width: 1200px;
  margin: 0 auto;
  padding: 2rem;
}

.header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 2rem;
}

.header h1 {
  color: #2c3e50;
  margin: 0;
}

.vessel-form {
  background: white;
  padding: 2rem;
  border-radius: 8px;
  box-shadow: 0 2px 4px rgba(0,0,0,0.1);
}

.form-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(400px, 1fr));
  gap: 2rem;
  margin-bottom: 2rem;
}

.form-section {
  background: #f8f9fa;
  padding: 1.5rem;
  border-radius: 8px;
  border: 1px solid #e9ecef;
}

.form-section.full-width {
  grid-column: 1 / -1;
}

.form-section h3 {
  color: #2c3e50;
  margin: 0 0 1rem 0;
  font-size: 1.25rem;
  border-bottom: 2px solid #3498db;
  padding-bottom: 0.5rem;
}

.form-group {
  margin-bottom: 1rem;
}

.form-group label {
  display: block;
  margin-bottom: 0.5rem;
  font-weight: 600;
  color: #555;
}

.form-input, .form-select, .form-textarea {
  width: 100%;
  padding: 0.75rem;
  border: 1px solid #ddd;
  border-radius: 4px;
  font-size: 1rem;
  transition: border-color 0.3s ease;
}

.form-input:focus, .form-select:focus, .form-textarea:focus {
  outline: none;
  border-color: #3498db;
  box-shadow: 0 0 0 2px rgba(52, 152, 219, 0.2);
}

.form-input.error, .form-select.error {
  border-color: #dc3545;
}

.error-message {
  color: #dc3545;
  font-size: 0.875rem;
  margin-top: 0.25rem;
  display: block;
}

.form-textarea {
  resize: vertical;
  min-height: 100px;
}

.form-actions {
  display: flex;
  gap: 1rem;
  justify-content: flex-end;
  padding-top: 2rem;
  border-top: 1px solid #e9ecef;
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

.btn-outline {
  background-color: transparent;
  color: #3498db;
  border: 1px solid #3498db;
}

.btn:disabled {
  opacity: 0.6;
  cursor: not-allowed;
}

.btn:hover:not(:disabled) {
  transform: translateY(-2px);
  box-shadow: 0 4px 8px rgba(0,0,0,0.1);
}

.error-banner {
  background-color: #f8d7da;
  color: #721c24;
  padding: 1rem;
  border-radius: 4px;
  margin-top: 1rem;
  border: 1px solid #f5c6cb;
}
</style>
