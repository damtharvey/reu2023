# TREU 2023

## Note: See below for instructions on how to install and run Jupyter Notebook with Anaconda or Miniconda.

# Installing Anaconda: 
We recommend using Anaconda or Miniconda to manage your Python environments.
The setup for Anaconda and Miniconda will essentially be the same. Look here: https://www.educative.io/answers/anaconda-vs-miniconda to read about the differences between Anaconda and Miniconda

## Installation steps
1. Download Anaconda installer for your system at https://www.anaconda.com/, or Miniconda at https://docs.conda.io/en/latest/miniconda.html.
2. Begin Installation Process:
- Linux/Unix: Open the terminal and run: `bash Anaconda-latest-Linux-x86_64.sh` or `bash Miniconda3-latest-MacOSX-x86_64.sh` as appropriate. You may need to enable execution first by running `chmod +x Anaconda-latest-Linux-x86_64.sh` or `chmod +x Miniconda3-latest-MacOSX-x86_64.sh`.
- Windows: Run the .exe installer
- macOS: Open the .pkg file
3. Follow the prompts on the screen
4. Verify your installation of conda by opening the terminal (or Anaconda Prompt on Windows) and running `conda list`. A list of installed packages should appear if it is installed correctly. Note: For macOS and Linux.Unix, you can verify in the terminal, but you will have to close and open your terminal again for changes to take effect.
5. To create an environment, use the command: `conda create -n environment_name`, where `environment_name` is any name you want to name your environment. Then activate your environment with `conda activate environment_name`.
6. To install Jupyter, with your environment activated, use the command: `conda install jupyter`
7. To open Jupyter Notebook, use the command: `jupyter notebook`

## Installing Miniconda to CHPC:
1. Open new terminal on your machine and connect to CHPC using command: `ssh [your_uid]@notchpeak.chpc.utah.edu`. The password is the same as for your Canvas account.
2. Download Miniconda installer:

```[u1111111@notchpeak1:~]$ wget https://repo.continuum.io/miniconda/Miniconda3-latest-Linux-x86_64.sh```

3. Run the installer:

```[u1111111@notchpeak1:~]$ bash ./Miniconda3-latest-Linux-x86_64.sh -b -p $HOME/software/pkg/miniconda3 -s```

4. Create an user environment module. First create a directory where the user environment module hierarchy will reside, and then copy our miniconda module file to this directory.

```[u1111111@notchpeak1:~]$ mkdir -p $HOME/MyModules/miniconda3```

```[u1111111@notchpeak1:~]$ cp /uufs/chpc.utah.edu/sys/installdir/python/modules/miniconda3/latest.lua $HOME/MyModules/miniconda3```

5. Load the user space miniconda module.

```[u1111111@notchpeak1:~]$ module use $HOME/MyModules```

```[u1111111@notchpeak1:~]$ module load miniconda3/latest```

6. Verify your installation of conda by running `conda list`.

7. To create an environment, use the command: `conda create -n environment_name`, where `environment_name` is any name you want to name your environment. 

8. Now initialize conda by typing `conda init --all`. After you are done, the session can be closed. Open another terminal within CHPC to activate your conda and install jupyter as described below. 

9. Then activate your environment with `conda activate environment_name`.

8. To install Jupyter, with your environment activated, use the command: `conda install jupyter`

9. Now, set up a kernel to use this conda environment from Jupyter Notebook

```
(your_env_name) [u1111111@notchpeak1:~]$ conda install ipykernel
(your_env_name) [u1111111@notchpeak1:~]$ python3 -m ipykernel install --user --name your_env_name --display-name "Python (your_env_name)"
``` 

10. Don't forget to clone this repository (if you haven't done it before)

```
(base) [u1111111@notchpeak1:~]$ git clone https://github.com/damtharvey/reu2023.git
```

11. Feel free to close this terminal after you are done.

# Installing Packages
**Python should already be installed in any environments you make with `conda`**. To install it manually, or to change the version, activate your environment and run `conda install python=version`, where `version` is the Python version you want to install, e.g. `3.10`. The material in this repository assumes you have at least version `3.10`.

Packages can be installed in your active envrionment using `conda install package` or `pip install package`. `pip` tends to have more packages available than `conda`.

For more information about conda environments, how to create and modify them, and what they can be useful for follow these links: 
 - https://conda.io/projects/conda/en/latest/user-guide/tasks/manage-environments.html
 - https://www.freecodecamp.org/news/why-you-need-python-environments-and-how-to-manage-them-with-conda-85f155f4353c/

# Using Jupyter Notebooks Remotely
You can use your local browser to view a Jupyter Notebook on any machine you have access to, such as your own GPU server.

On the remote server, with your environment activated,
```
jupyter notebook --no-browser --port=8080
```
This should give your some http links. Copy any one of those links. You can change the port number from 8080 if you prefer.

Then, on your local machine, e.g. your laptop, run
```
ssh -L 8080:localhost:8080 yourname@remoteserver
```
where `yourname` is your user name and `remoteserver` is the host name of the remote server.

Then, open a web browser and paste the link that you copied from before.

If you do not have a remote machine or GPU on your machine, you can use CHPC (super-computer of the University of Utah).

## Using Jupyter Notebooks on CHPC
1. Follow the instructions on Miniconda Installation for CHPC (if you haven't done it yet on CHPC).

2. Using your web-browser on the local machine open new window with the following address:
```
https://ondemand.chpc.utah.edu
```

3. Log in using your Username and Password.

4. Now you are on CHPC. Choose Jupyter among all the Pinned Apps

5. Create a Notebook, choose account and partition so, that it will contain "gpu" in both names. Choose Advanced Options - GPU-type [any] and click to launch

6. After a successful start connect to the Notebook, choose the Notebook you want to launch

7. After launch, in widgets go to `Kernel` -> `change Kernel` -> `Python (your env)`

8. Enjoy! 

# Working with CHPC through terminal

1. Open your terminal and connect to CHPC using ssh protocol (change u1111111 to your ID), the password will be your university password.
```
user@user:~$ ssh u1111111@notchpeak.chpc.utah.edu
```

2. Make sure that you have installed Miniconda on CHPC. It is easy to check, if you have indicator `(base)` in your terminal - you are good. Otherwise you need to go to the instructions above.

3. Once you are done, write command "myallocation", you should get something like this:
```
(base) [u1111111@notchpeak1:~]$ myallocation
	You have a general allocation on kingspeak. Account: cs-reu, Partition: kingspeak
	You have a general allocation on kingspeak. Account: cs-reu, Partition: kingspeak-shared
	You have an owner allocation on kingspeak. Account: soc-gpu-kp, Partition: soc-gpu-kp
	You have an owner allocation on kingspeak. Account: soc-gpu-kp, Partition: soc-shared-gpu
	You have an owner allocation on kingspeak. Account: soc-kp, Partition: soc-kp
	You have an owner allocation on kingspeak. Account: soc-kp, Partition: soc-shared-kp
	You can use preemptable mode on kingspeak. Account: owner-guest, Partition: kingspeak-guest
	You can use preemptable GPU mode on kingspeak. Account: owner-gpu-guest, Partition: kingspeak-gpu-guest
	You have a GPU allocation on kingspeak. Account: soc-gpu-kp, Partition: soc-gpu-kp
	You have a GPU allocation on kingspeak. Account: kingspeak-gpu, Partition: kingspeak-gpu
	Your group cs-reu does not have a general allocation on notchpeak
	You can use preemptable mode on notchpeak. Account: cs-reu, Partition: notchpeak-freecycle
	You can use preemptable mode on notchpeak. Account: cs-reu, Partition: notchpeak-shared-freecycle
	You have a general allocation on notchpeak. Account: dtn, Partition: notchpeak-dtn
	You have a general allocation on notchpeak. Account: notchpeak-shared-short, Partition: notchpeak-shared-short
	You have an owner allocation on notchpeak. Account: soc-gpu-np, Partition: soc-gpu-np
	You have an owner allocation on notchpeak. Account: soc-gpu-np, Partition: soc-shared-gpu
	You have an owner allocation on notchpeak. Account: coe-np, Partition: coestudent-np
	You have an owner allocation on notchpeak. Account: coe-np, Partition: coestudent-shared-np
	You can use preemptable GPU mode on notchpeak. Account: owner-gpu-guest, Partition: notchpeak-gpu-guest
	You can use preemptable mode on notchpeak. Account: owner-guest, Partition: notchpeak-guest
	You have a GPU allocation on notchpeak. Account: soc-gpu-np, Partition: soc-gpu-np
	You have a GPU allocation on notchpeak. Account: notchpeak-gpu, Partition: notchpeak-gpu
	You have a general allocation on lonepeak. Account: cs-reu, Partition: lonepeak
	You have a general allocation on lonepeak. Account: cs-reu, Partition: lonepeak-shared
	You can use preemptable mode on lonepeak. Account: owner-guest, Partition: lonepeak-guest
	You have a GPU allocation on lonepeak. Account: lonepeak-gpu, Partition: lonepeak-gpu
```

4. Now we need to allocate resources on our account, we need to determine: how many cores we want, do we want GPU or not, for how long we are going to use our account.

   Select an account and partition with GPU, here it can be soc-gpu-np:soc-gpu-np, notchpeak-gpu:notchpeak-gpu (containts gpu). Also pay attention to an allocation for this account (notchpeak/lonepeak...)

5. Let's connect to the chosen account to access gpu resources. Here is an example for allocation:notchpeak, account:soc-gpu-np, partition:soc-gpu-np, allocation for 1 hour(-t), 1 physical compute node (--nodes) and 1 logical process (--ntasks)
```
(base) [u1111111@notchpeak1:~]$ srun -M notchpeak --account=soc-gpu-np --partition=soc-gpu-np --nodes=1 --ntasks=1 --gres=gpu -t 1:00:00 --pty bash
```

6. After success, we are on the GPU-allocation from where we can launch anything we want. Use the following commands to activate conda environment and load module cuda (for GPU):
```
(base) [u1111111@notch367:~]$ conda activate [your_env_name]
(your_env_name) [u1111111@notch367:~]$ ml cuda
```

7. Now you are on your own to launch anything you want!
